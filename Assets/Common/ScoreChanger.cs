using System;
using Config;
using Methods.Additive;
using Methods.ScriptableObject;
using Methods.SingletonMonobehaviour;
using Methods.Static;
using Methods.VContainerEnqueueParent;
using Methods.VContainerRootLifetimeScope;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Common
{
    public sealed class ScoreChanger : MonoBehaviour
    {
        [SerializeField] private ProvideTypeConfig config = default;
        [SerializeField] private Button scoreAddButton = default;
        
        private void Awake()
        {
            scoreAddButton.onClick.AddListener(AddScore);
        }

        private void OnDestroy()
        {
            scoreAddButton.onClick.RemoveListener(AddScore);
        }

        #region VContainer

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

        private void AddScore()
        {
            switch (config.ProvideType)
            {
                case ProvideType.Static:
                    GameScoreStatic.Score++;
                    break;
                case ProvideType.Singleton:
                    GameScoreSingleton.Instance.Score++;
                    break;
                case ProvideType.Additive:
                    FindObjectOfType<GameScoreMonoBehaviour>().Score++;
                    break;
                case ProvideType.VContainer_EnqueueParent:
                    scoreHolderEnqueueParent.Score++;
                    break;
                case ProvideType.VContainer_RootLifetimeScope:
                    scoreHolderRoot.Score++;
                    break;
                case ProvideType.ScriptableObject:
                    scoreScriptableObject.Score++;
                    break;
                default:
                    throw new NotImplementedException();
            }    
        }
    }
}