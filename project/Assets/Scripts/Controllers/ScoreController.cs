using UnityEngine;
using TMPro;

namespace ProjectGame
{
    public class ScoreController : MonoBehaviour
    {
        public TextMeshProUGUI textMesh;

        private int score = 0;

        void Update()
        {
            UpdateScore();
        }

        void UpdateScore()
        {
            textMesh.text = "Score: " + score.ToString();
        }

        public void IncrementScore(int bonus)
        {
            score += bonus;
        }

    }
}

