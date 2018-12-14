using CatFish;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScoreBoard : ScriptableObject {

    public int collectiblesCount;
    public int collectiblesWeight;
    public int deathsCount;
    public int deathsWeight;

    public string levelName;

    public string nextLevelName;
}
