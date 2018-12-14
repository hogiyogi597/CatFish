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

        [Header("Score Object")]
        public ScoringObject score;
        public ScoreBoard scoreboard;

        [Header("Text Object")]
        public Text scoreUI;

        // Use this for initialization
        void Awake()
        {
            ResetScore();
        }

        // Update is called once per frame
        void Update()
        {
            scoreUI.text = "Score: " + score.levelScore;
        }

        public void CollectedItem()
        {
            totalScore += collectiblePoint;
            score.levelScore += collectiblePoint;
            score.collectibleCount++;
        }

        public void Died()
        {
            totalScore -= deathPoint;
            score.levelScore -= deathPoint;
            score.deathCount++;
            ResetScore();
        }

        public void ResetScore()
        {
            //collectiblesCount = score.collectibleCount;
            //deathCount = score.deathCount;
            //score.levelScore = collectiblesCount * collectiblePoint - deathCount * deathPoint;
        }

        public void ShowScoreBoard(string nextLevel)
        {
            scoreboard.collectiblesCount = score.collectibleCount;
            scoreboard.collectiblesWeight = collectiblePoint;
            scoreboard.deathsCount = score.deathCount;
            scoreboard.deathsWeight = deathPoint;
            scoreboard.nextLevelName = nextLevel;
            switch(nextLevel)
            {
                case "Level2":
                    scoreboard.levelName = "Level1";
                    break;
                case "Level3":
                    scoreboard.levelName = "Level2";
                    break;
                default:
                    scoreboard.levelName = "Level3";
                    break;

            }
            score.deathCount = 0;
            score.collectibleCount = 0;
            score.levelScore = 0;
            GameObject.FindObjectOfType<SceneLoader>().LoadScene("ScoreBoard");
        }
    }

}