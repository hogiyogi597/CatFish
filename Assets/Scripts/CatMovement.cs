using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CatMovement : MonoBehaviour {


    [Header("Controls")]
    public KeyCode jumpKey = KeyCode.Space;
    public SpriteRenderer playerSpriteRenderer;

    [Header("Movement Settings")]
    [Range(0.01f, 1.00f)]
    public float speed = 0.5f;
    public float jumpHeight = 10f;
    [Range(1, 2)]
    public int jumpCount = 1;

    private Rigidbody2D playerBody;
    private bool facingRight = true;
    private bool canWallJump = false;
    private bool grounded = false;
    private Vector3 wallJumpAngle = new Vector3();
    private Vector3 jumpStart = new Vector3();

	// Use this for initialization
	void Start () {
        playerBody = this.GetComponent<Rigidbody2D>();
        playerSpriteRenderer = this.GetComponentInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        Animate();
        Move();
        Jump();
        
	}

    private void Animate()
    {
        playerSpriteRenderer.flipX = !facingRight;
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        this.transform.Translate(new Vector2(horizontalInput, 0) * speed);
        if(horizontalInput < 0)
        {
            facingRight = false;
        } else if (horizontalInput > 0)
        {
            facingRight = true;
        }
    }

    private void Jump()
    {

        if(jumpCount > 0 && Input.GetKeyDown(jumpKey))
        {
            jumpStart = transform.position;
            jumpCount--;
            playerBody.AddForce(new Vector2(wallJumpAngle.normalized.x, jumpHeight), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canWallJump = false;
            jumpStart = new Vector3();
            grounded = true;
            jumpCount = 1;
        }
        if (collision.gameObject.tag == "Wall" && !canWallJump)
        {
            Debug.Log(playerBody.velocity);
            wallJumpAngle = -1 * (transform.position - jumpStart);
            Debug.Log("wallJumpAngle: " + wallJumpAngle);
            canWallJump = true;
            jumpCount++;
        }
    }
}
