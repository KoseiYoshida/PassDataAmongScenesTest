using System;
using Config;
using Methods.Additive;
using Methods.ScriptableObject;
using Methods.SingletonMonobehaviour;
using Methods.Static;
using Methods.VContainerEnqueueParent;
using Methods.VContainerRootLifetimeScope;
using UnityEngine;
using VContainer;

namespace Common
{
    public sealed class ScoreProvider : MonoBehaviour
    {
        [SerializeField] private ProvideTypeConfig config = default;

        #region VContaier
        private ScoreHolderEnqueueParent scoreHolderEnqueueParent = default;
        private ScoreHolderRoot scoreHolderRoot = default;

        [Inject]
        public void Construct(ScoreHolderEnqueueParent holderEnqueueParent)
        {
            scoreHolderEnqueueParent = holderEnqueueParent;
        }
        
        [Inject]
        public void Construct(ScoreHolderRoot holderRoot)
        {
            scoreHolderRoot = holderRoot;
        }
        #endregion

        #region ScriptableObject

        [SerializeField] private ScoreScriptableObject scoreScriptableObject = default;

        #endregion
        
        public int GetScore()
        {
            switch (config.ProvideType)
            {
                case ProvideType.Static:
                    return GameScoreStatic.Score;
                case ProvideType.Singleton:
                    return GameScoreSingleton.Instance.Score;
                case ProvideType.Additive:
                    return FindObjectOfType<GameScoreMonoBehaviour>().Score;
                case ProvideType.VContainer_EnqueueParent:
                    return scoreHolderEnqueueParent.Score;
                case ProvideType.VContainer_RootLifetimeScope:
                    return scoreHolderRoot.Score;
                case ProvideType.ScriptableObject:
                    return scoreScriptableObject.Score;
                default:
                    throw new NotImplementedException();
            }    
        }
    }
}