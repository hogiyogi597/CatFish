using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CatFish
{
    public class SnapToDoor : MonoBehaviour {

        private PlatformerCameraFollow cameraFollow;
        private Transform returnTransform;
        bool show;

        // Use this for initialization
        void Start () {
            cameraFollow = this.GetComponent<PlatformerCameraFollow>();
	    }
	
	    // Update is called once per frame
	    void Update () {
		
	    }

        private IEnumerator PlayCinematic(Transform door)
        {
            returnTransform = cameraFollow.followTransform;
            cameraFollow.followTransform = door;
            yield return new WaitForSeconds(2);
            show = false;
            cameraFollow.followTransform = returnTransform;
        }

        public void SnapTo(Transform door)
        {
            StartCoroutine(PlayCinematic(door));
        }


    }
}
