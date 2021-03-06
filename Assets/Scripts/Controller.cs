﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatFish
{
    public abstract class Controller : MonoBehaviour
    {

        [Header("Controls")]
        public KeyCode jumpKey = KeyCode.Space;

        [Header("Movement Settings")]
        [Range(0.01f, 1.00f)]
        public float speed = 0.5f;
        public float jumpHeight = 10f;

        [Header("Jump Sound")]
        public AudioClip jumpSound;

        // movement and physics
        protected Rigidbody2D playerBody;
        protected Vector3 storedVelocity;
        protected bool isFrozen = false;

        // animation
        public SpriteRenderer playerSpriteRenderer;
        protected bool facingRight = true;

        protected Animator animator;

        protected AudioManager audio;

        // Use this for initialization
        protected void Start()
        {
            playerBody = this.GetComponent<Rigidbody2D>();
            animator = this.GetComponent<Animator>();
            audio = FindObjectOfType<AudioManager>();
        }

        // Update is called once per frame
        protected void Update()
        {
            if (isFrozen)
            {
                //this.transform.Translate(this.transform.position);
                playerBody.velocity = Vector2.zero;
                return;
            }
            Animate();
            Move();
            if (Input.GetKeyDown(jumpKey)) Jump();
        }

        protected void Animate()
        {
            playerSpriteRenderer.flipX = !facingRight;

        }

        protected virtual void Move()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            this.transform.Translate(new Vector2(horizontalInput, 0) * speed);
            animator.SetFloat("speed", Mathf.Abs(horizontalInput));
            //playerBody.velocity = new Vector3(, playerBody.velocity.y, 0);
            if (horizontalInput < 0)
            {
                facingRight = false;
            }
            else if (horizontalInput > 0)
            {
                facingRight = true;
            }
        }
        protected abstract void Jump();

        public void Freeze(bool value)
        {
            isFrozen = value;

            if (value)
            {
                storedVelocity = playerBody.velocity;
                playerBody.velocity = Vector3.zero;

            }
            else
            {
                playerBody.velocity = storedVelocity;
            }
        }
    }
}