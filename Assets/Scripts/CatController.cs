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

        private bool grounded = false;
        private Vector3 wallJumpAngle = new Vector3();
        private Vector3 jumpStart = new Vector3();
        private GameObject lastWallJumped;

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

        protected override void Jump()
        {
            if (jumpCount > 0)
            {
                jumpStart = transform.position;
                ResetJump(0);
                playerBody.AddForce(new Vector2(wallJumpAngle.normalized.x, jumpHeight), ForceMode2D.Impulse);
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

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "MovingPlatform")
            {
                jumpStart = new Vector3();
                grounded = true;
                ResetJump();
                lastWallJumped = null;
                animator.SetBool("isJumping", false);
            }
            if (collision.gameObject.tag == "Wall")
            {
                if (lastWallJumped != null && lastWallJumped.Equals(collision.gameObject))
                {
                    return;
                }
                wallJumpAngle = -1 * (transform.position - jumpStart);
                ResetJump();
                lastWallJumped = collision.gameObject;
                animator.SetBool("isJumping", false);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "MovingPlatform")
            {
                this.transform.parent = null;
            }
        }

        void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Wall" && lastWallJumped != null && lastWallJumped.Equals(collision.gameObject))
            {
                return;
            }
            if (collision.gameObject.tag == "MovingPlatform")
            {
                this.transform.parent = collision.transform;
            }
        }
    }

}