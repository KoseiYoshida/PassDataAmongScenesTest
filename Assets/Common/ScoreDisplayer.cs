using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public sealed class ScoreDisplayer : MonoBehaviour
    {
        [SerializeField] private ScoreProvider scoreProvider = default;
        [SerializeField] private Text scoreText;
        
        private void Update()
        {
            scoreText.text = scoreProvider.GetScore().ToString();
        }
    }
}