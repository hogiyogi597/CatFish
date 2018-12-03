using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatFish
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CatController : Controller
    {
        [Range(1, 2)]
        public int jumpCount = 1;
        public Vector2 wallJump;

        private bool grounded = false;
        private Vector3 wallJumpAngle = new Vector3();
        private Vector3 jumpStart = new Vector3();
        private GameObject lastWallJumped;
        private bool collidingRight = true;
        private bool onCooldown = false;

        // Use this for initialization
        void Start()
        {
            base.Start();
            playerBody = this.GetComponent<Rigidbody2D>();
            playerSpriteRenderer = this.GetComponentInChildren<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            base.Update();

        }

        protected override void Move()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            //Vector2 move = playerBody.velocity.x == 0 ? new Vector2(horizontalInput, 0) * speed : playerBody.velocity;
            if(!onCooldown && (horizontalInput < -0.1f || horizontalInput > 0.1f))
            {
                this.transform.Translate(new Vector2(horizontalInput, 0) * speed);
                playerBody.velocity = new Vector2(0, playerBody.velocity.y);
            }

            animator.SetFloat("speed", Mathf.Abs(horizontalInput));
            if (horizontalInput < 0)
            {
                facingRight = false;
            }
            else if (horizontalInput > 0)
            {
                facingRight = true;
            }
        }

        protected override void Jump()
        {
            if (jumpCount > 0)
            {
                audio.PlaySound(jumpSound);
                jumpStart = transform.position;
                if(!grounded)
                {
                    Debug.Log("wall jump test");
                    int wallJumpDir = collidingRight ? -1 : 1;
                    playerBody.velocity = Vector3.zero;
                    playerBody.AddForce(new Vector2(-wallJumpDir * wallJump.x, wallJump.y), ForceMode2D.Impulse);
                    StartCoroutine("StartCooldown");
                }
                else
                {
                    playerBody.AddForce(new Vector2(wallJumpAngle.normalized.x, jumpHeight), ForceMode2D.Impulse);
                }
                ResetJump(0);
                animator.SetBool("isJumping", true);
            }
        }

        private void ResetJump()
        {
            ResetJump(1);
        }

        private void ResetJump(int newVal)
        {
            jumpCount = newVal;
        }

        private bool isCollidingRight(Collision2D collision)
        {
            bool res = this.transform.position.x > collision.transform.position.x;
            return res;
        }

        private IEnumerator StartCooldown()
        {
            onCooldown = true;
            yield return new WaitForSeconds(0.3f);
            onCooldown = false;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            bool collidedWithGround = false;
            if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "MovingPlatform")
            {
                jumpStart = new Vector3();
                playerBody.velocity = Vector3.zero;
                grounded = true;
                collidedWithGround = true;
                ResetJump();
                lastWallJumped = null;
                animator.SetBool("isJumping", false);
            }
            if (collision.gameObject.tag == "Wall")
            {
                grounded = collidedWithGround;
                if (lastWallJumped != null && lastWallJumped.Equals(collision.gameObject))
                {
                    return;
                }
                collidingRight = isCollidingRight(collision);
                wallJumpAngle = -1 * (transform.position - jumpStart);
                ResetJump();
                lastWallJumped = collision.gameObject;
                animator.SetBool("isJumping", false);
            }
            if (!(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "MovingPlatform" || collision.gameObject.tag == "Wall"))
            {
                Debug.Log(collision.gameObject.name);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "MovingPlatform")
            {
                grounded = false;
                this.transform.parent = null;
            }
            if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "MovingPlatform")
            {
                grounded = false;
                ResetJump(0);
                animator.SetBool("isJumping", true);
            }
        }

        void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "MovingPlatform")
            {
                grounded = true;
            }
            if (collision.gameObject.tag == "Wall" && lastWallJumped != null && lastWallJumped.Equals(collision.gameObject))
            {
                return;
            }
            if (collision.gameObject.tag == "MovingPlatform")
            {
                grounded = true;
                this.transform.parent = collision.transform;
            }

        }
    }

}