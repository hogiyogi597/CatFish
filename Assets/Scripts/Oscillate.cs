using UnityEngine;

namespace CatFish
{
    [RequireComponent(typeof(Transform))]
    public class Oscillate : MonoBehaviour
    {

        [Header("Positions")]
        public float displacement;
        public Utils.Direction startDirection;
        public float timeFrame = 2f;

        [Header("Orientation")]
        public Utils.Orientation orientation;

        private Transform t;
        private bool stopOscillating = false;
        private float offset;
        private int startDirectionMultiplier;

        // Use this for initialization
        void Start()
        {
            t = this.GetComponent<Transform>();
            offset = GetStartingPosition();
            startDirectionMultiplier = Utils.ToDirectionalInt(startDirection);
        }

        // Update is called once per frame
        void Update()
        {
            if (stopOscillating)
            {
                return;
            }
            float temp = offset + Mathf.Sin(Time.time * timeFrame) * displacement * startDirectionMultiplier;
            switch (orientation)
            {
                case Utils.Orientation.X:
                    this.gameObject.transform.position = new Vector3(temp, transform.position.y, transform.position.z);
                    break;
                case Utils.Orientation.Y:
                    this.gameObject.transform.position = new Vector3(transform.position.x, temp, transform.position.z);
                    break;
                case Utils.Orientation.Z:
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
            switch (orientation)
            {
                case Utils.Orientation.X:
                    val = this.transform.position.x;
                    break;
                case Utils.Orientation.Y:
                    val = this.transform.position.y;
                    break;
                case Utils.Orientation.Z:
                    val = this.transform.position.z;
                    break;
            }
            return val;
        }

    }

}