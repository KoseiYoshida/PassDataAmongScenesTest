using System;
using UnityEngine;

namespace Methods.ScriptableObject
{
    [CreateAssetMenu(fileName = "ScoreScriptableObject", menuName = "ScoreScriptableObject", order = 0)]
    public class ScoreScriptableObject : UnityEngine.ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private int initScore = default;
        [NonSerialized] public int Score;
        
        public void OnAfterDeserialize()
        {
            Score = initScore;
        }

        public void OnBeforeSerialize() { /* do nothing */ }
    }

    
    // TODO: ↑のやり方は冗長なので汎用クラスをつくりたい
    // [CreateAssetMenu(fileName = "ScoreScriptableObject", menuName = "ScoreScriptableObject", order = 0)]
    // public class ScoreScriptableObject : UnityEngine.ScriptableObject, ISerializationCallbackReceiver
    // {
    //     [SerializeField] private ScriptableValue<int> score = default;
    //
    //     public int Score
    //     {
    //         get => score.RuntimeValue;
    //         set => score.RuntimeValue = value;
    //     }
    //     
    //     public void OnAfterDeserialize()
    //     {
    //         score.Init();
    //     }
    //
    //     public void OnBeforeSerialize() { /* do nothing */ }
    // }
    //
    // [System.Serializable]
    // public class ScriptableValue<T>
    // {
    //     [SerializeField] private T initialValue = default(T);
    //     [NonSerialized] public T RuntimeValue;
    //
    //     public void Init()
    //     {
    //         RuntimeValue = initialValue;
    //     }
    // }
}