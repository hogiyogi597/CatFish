using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingCatPawManager : MonoBehaviour {

    public GameObject pawPrefab;

	// Use this for initialization
	void Start () {
        foreach( GameObject wall in GameObject.FindGameObjectsWithTag("Wall"))
        {
            Vector3 newPos = wall.transform.position;
            newPos.z = -5;
            GameObject catPaw = Instantiate(pawPrefab, newPos, wall.transform.rotation);
            //catPaw.transform.SetParent(wall.transform);
            catPaw.GetComponent<GlowingCatPaw>().Initialize(wall.transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
