using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CatFish
{
    public class PlayerInteraction : MonoBehaviour
    {

        public string playerTag = "Player";

        public UnityEvent playerInteractionEvent;

        public UnityEvent playerInteractionExitEvent;

        public bool continuousInteraction = false;


        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(playerTag))
            {
                playerInteractionEvent.Invoke();
            }
        }

        public void OnTriggerStay2D(Collider2D other)
        {
            if (continuousInteraction && other.CompareTag(playerTag))
            {
                playerInteractionEvent.Invoke();
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(playerTag))
            {
                playerInteractionExitEvent.Invoke();
            }
        }
    }
}