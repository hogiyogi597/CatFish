using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatFish
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class WaterFlow : MonoBehaviour {

        public string playerTag = "Player";
        public Utils.Orientation orientation;
        public Utils.Direction pushDirection;
        public float waterStrength;

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag(playerTag))
            {
                Rigidbody2D playerBody = other.GetComponent<Rigidbody2D>();
                int directionalInt = Utils.ToDirectionalInt(pushDirection);
                float distanceFromPipe = GetDistanceFromPipe(other.transform.position);
                switch (orientation)
                {
                    case Utils.Orientation.X:
                        playerBody.AddForce(new Vector2((directionalInt * waterStrength) / distanceFromPipe, 0), ForceMode2D.Impulse);
                        break;
                    case Utils.Orientation.Y:
                        playerBody.AddForce(new Vector2(0, (directionalInt * waterStrength) / distanceFromPipe), ForceMode2D.Impulse);
                        break;
                    case Utils.Orientation.Z:
                        throw new UnityException("Cannot push in the Z direction because it is 2D");
                }
            }
        }

        private float GetDistanceFromPipe(Vector3 other)
        {
            Vector2 temp = this.transform.position - other;
            switch (orientation)
            {
                case Utils.Orientation.X:
                    return Math.Abs(temp.x);
                case Utils.Orientation.Y:
                    return Math.Abs(temp.y);
                case Utils.Orientation.Z:
                    throw new UnityException("Cannot push in the Z direction because it is 2D");
            }
            return 0;
        }
    }
}
