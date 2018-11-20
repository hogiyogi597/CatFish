using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {
	

    public float rotationSpeed;
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(0, rotationSpeed, 0);
        //this.transform.rotation.y += rotationSpeed;
	}
}
