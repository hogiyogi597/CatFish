using CatFish;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardManager : MonoBehaviour {

    public ScoreBoard scoreboard;

    public Text level;
    public Text collectibles;
    public Text deaths;
    public Text total;

	// Use this for initialization
	void Start () {
        level.text = scoreboard.levelName;
        collectibles.text = CalculatedString(scoreboard.collectiblesCount, scoreboard.collectiblesWeight);
        deaths.text = CalculatedString(scoreboard.deathsCount, -scoreboard.deathsWeight);
        total.text = scoreboard.collectiblesCount * scoreboard.collectiblesWeight - scoreboard.deathsCount * scoreboard.deathsWeight + "";
	}
	
	private string CalculatedString(int count, int weight)
    {
        return count + " x " + weight + " = " + count * weight;
    }

    public void LoadNextLevel()
    {
        GameObject.FindObjectOfType<SceneLoader>().LoadScene(scoreboard.nextLevelName);
    }
}
