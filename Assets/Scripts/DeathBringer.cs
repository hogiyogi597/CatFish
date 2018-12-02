using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatFish
{
    public class DeathBringer : MonoBehaviour {
        private string playerTag = "Player";

        private CatController catController;
        private FishController fishController;
        private SceneLoader sceneLoader;
        private ScoreManager scoreManager;
        private CharacterManager characterManager;

	    // Use this for initialization
	    void Start () {
            catController = GameObject.Find("Cat").GetComponent<CatController>();
            fishController = GameObject.Find("Fish").GetComponent<FishController>();
            GameObject gameManager = GameObject.Find("GameManager");
            sceneLoader = gameManager.GetComponent<SceneLoader>();
            scoreManager = gameManager.GetComponent<ScoreManager>();
            characterManager = gameManager.GetComponent<CharacterManager>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(playerTag))
            {
                catController.Freeze(true);
                fishController.Freeze(true);
                scoreManager.Died();
                characterManager.Died();
                sceneLoader.RestartScene();
            }
        }
    }

}
