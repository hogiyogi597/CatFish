using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {

    [Header("World Manager")]
    public PlatformerCameraFollow cameraFollow;
    public GameObject cat;
    public GameObject fish;

    [Header("Controls")]
    public KeyCode switchCharacter = KeyCode.F;
    public KeyCode switchCharacterAlt = KeyCode.RightControl;

    // Use this for initialization
    void Start () {
        cameraFollow.followTransform = cat.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(switchCharacter) || Input.GetKeyDown(switchCharacterAlt))
        {
            SwitchCharacters();
            
        }
	}

    private void SwitchCharacters()
    {
        if(cameraFollow.followTransform == cat.transform)
        {
            cat.GetComponentInChildren<Controller>().Freeze(true);
            fish.GetComponentInChildren<Controller>().Freeze(false);
            cameraFollow.followTransform = fish.transform;
        }
        else
        {
            cat.GetComponentInChildren<Controller>().Freeze(false);
            fish.GetComponentInChildren<Controller>().Freeze(true);
            cameraFollow.followTransform = cat.transform;
        }
    }
}
