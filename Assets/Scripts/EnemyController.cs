using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {


    public float speed;
    public float offset;

    private bool facingRight;
    private Vector3 startingPosition;
    private float minX;
    private float maxX;

	// Use this for initialization
	void Start () {
        facingRight = false;
        startingPosition = this.transform.position;
        minX = startingPosition.x - offset;
        maxX = startingPosition.x + offset;
    }
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    void Move()
    {
        int directionModifier = facingRight ? 1 : -1;
        float updatedX = speed * Time.deltaTime * directionModifier;
        this.transform.Translate(new Vector2(updatedX, 0));
        if (this.transform.position.x <= minX)
        {
            facingRight = true;
            this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (this.transform.position.x >= maxX)
        {
            facingRight = false;
            this.transform.localScale = new Vector3(this.transform.localScale.x * -1, this.transform.localScale.y, this.transform.localScale.z);
        }
    }
}
