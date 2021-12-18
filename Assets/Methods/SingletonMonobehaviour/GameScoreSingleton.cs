using UnityEngine;

namespace Methods.SingletonMonobehaviour
{
    // GameObjectにアタッチして最初のシーンに置かれる想定
    public sealed class GameScoreSingleton : MonoBehaviour
    {
        private static GameScoreSingleton instance;

        public static GameScoreSingleton Instance => instance;


        public int Score = 0;

        private void Awake()
        {
            if (instance && this != instance)
            {
                Destroy(this.gameObject);
            }

            instance = this;
            DontDestroyOnLoad(this);
        }
    }
}