using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatFish
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class FishController : Controller
    {

        // Use this for initialization
        void Start()
        {
            playerBody = this.GetComponent<Rigidbody2D>();
            playerSpriteRenderer = this.GetComponentInChildren<SpriteRenderer>();
            Freeze(true);
        }

        // Update is called once per frame
        void Update()
        {
            base.Update();
        }

        protected override void Jump()
        {
            playerBody.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
    }

}