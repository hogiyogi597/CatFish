using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CatFish
{
    public class ScoreManager : MonoBehaviour
    {

        [Header("Score Modifiers")]
        public int deathPoint = 100;
        public int collectiblePoint = 150;

        private int totalScore = 0;

        [Header("Text Object")]
        public Text scoreUI;


        // Use this for initialization
        void Awake()
        {
            if (PlayerPrefs.HasKey("Score"))
            {
                totalScore = PlayerPrefs.GetInt("Score");
            }
            // Assign the high score to HighScore
            PlayerPrefs.SetInt("Score", totalScore);
        }

        // Update is called once per frame
        void Update()
        {
            scoreUI.text = "Score: " + totalScore;
            PlayerPrefs.SetInt("Score", totalScore);
        }

        public void CollectedItem()
        {
            totalScore += collectiblePoint;
        }

        public void Died()
        {
            
            totalScore -= deathPoint;
        }
    }

}