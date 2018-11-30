using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatFish
{
    public class CharacterManager : MonoBehaviour
    {

        [Header("World Manager")]
        public PlatformerCameraFollow cameraFollow;
        public GameObject cat;
        public GameObject fish;

        [Header("Sounds")]
        public AudioSource source;
        public AudioClip fishSound;
        public AudioClip catSound;
        public AudioClip catDeathSound;
        public AudioClip fishDeathSound;

        [Header("Controls")]
        public KeyCode switchCharacter = KeyCode.F;
        public KeyCode switchCharacterAlt = KeyCode.RightControl;

        // Use this for initialization
        void Start()
        {
            cameraFollow.followTransform = cat.transform;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(switchCharacter) || Input.GetKeyDown(switchCharacterAlt))
            {
                SwitchCharacters();

            }
        }

        private void SwitchCharacters()
        {
            if (cameraFollow.followTransform == cat.transform)
            {
                source.PlayOneShot(fishSound);
                cat.GetComponentInChildren<Controller>().Freeze(true);
                fish.GetComponentInChildren<Controller>().Freeze(false);
                cameraFollow.followTransform = fish.transform;
            }
            else
            {
                source.PlayOneShot(catSound);
                cat.GetComponentInChildren<Controller>().Freeze(false);
                fish.GetComponentInChildren<Controller>().Freeze(true);
                cameraFollow.followTransform = cat.transform;
            }
        }

        public void Died()
        {
            if (cameraFollow.transform == cat.transform)
                CatDied();
            else
                FishDied();
        }

        private void CatDied()
        {
            source.PlayOneShot(catDeathSound);
        }

        private void FishDied()
        {
            source.PlayOneShot(fishDeathSound);
        }
    }

}