using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{

    public string playerTag = "Player";

    public UnityEvent playerInteractionEvent;

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
}