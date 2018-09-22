using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class Oscillate : MonoBehaviour {

    public enum Orientation { X, Y, Z };

    [Header("Positions")]
    public float displacement;
    public float timeFrame = 2f;

    [Header("Orientation")]
    public Orientation orientation;

    private Transform t;
    private bool stopOscillating = false;
    private float offset;

    // Use this for initialization
    void Start () {
        t = this.GetComponent<Transform>();
        offset = GetStartingPosition();
    }
	
	// Update is called once per frame
	void Update () {
        if( stopOscillating)
        {
            return;
        }
        float temp = offset + Mathf.Sin(Time.time * timeFrame) * displacement;
        switch(orientation)
        {
            case Orientation.X:
                this.gameObject.transform.position = new Vector3(temp, transform.position.y, transform.position.z);
                break;
            case Orientation.Y:
                this.gameObject.transform.position = new Vector3(transform.position.x, temp, transform.position.z);
                break;
            case Orientation.Z:
                this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, temp);
                break;
        }
    }

    public void StopOscillating()
    {
        stopOscillating = true;
    }

    private float GetStartingPosition()
    {
        float val = 0;
        switch(orientation)
        {
            case Orientation.X:
                val = this.transform.position.x;
                break;
            case Orientation.Y:
                val = this.transform.position.y;
                break;
            case Orientation.Z:
                val = this.transform.position.z;
                break;
        }
        return val;
    }

}
