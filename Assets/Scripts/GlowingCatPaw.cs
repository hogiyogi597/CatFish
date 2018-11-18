using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingCatPaw : MonoBehaviour {

    public float colliderOffset;

    private BoxCollider2D collider2D;
    
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Initialize(Transform parent)
    {
        collider2D = this.gameObject.GetComponent<BoxCollider2D>();
        Vector2 parentCollider = parent.localScale;
        collider2D.size = new Vector2(parentCollider.x + colliderOffset, parentCollider.y);
        Debug.Log("parentColliderSize: " + parentCollider + " | childColliderSize: " + collider2D.size, this);
    }
}
