using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CatFish
{
    public class SnapToDoor : MonoBehaviour {

        private PlatformerCameraFollow cameraFollow;
        private Transform returnTransform;
        private CharacterManager manager;
        bool show;

        // Use this for initialization
        void Start () {
            cameraFollow = this.GetComponent<PlatformerCameraFollow>();
            manager = FindObjectOfType<CharacterManager>();
	    }
	
	    // Update is called once per frame
	    void Update () {
		
	    }

        private IEnumerator PlayCinematic(Transform door)
        {
            manager.ToggleSwitch();
            returnTransform = cameraFollow.followTransform;
            cameraFollow.followTransform = door;
            yield return new WaitForSeconds(2);
            show = false;
            cameraFollow.followTransform = returnTransform;
            manager.ToggleSwitch();
        }

        public void SnapTo(Transform door)
        {
            StartCoroutine(PlayCinematic(door));
        }


    }
}
