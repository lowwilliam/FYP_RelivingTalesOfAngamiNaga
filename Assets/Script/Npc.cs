using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public DialogueTrigger trigger;

    private void OnCollisionEnter2D(Collision2D other)
    {
        // UnityEngine.Debug.Log("started Conversation! Load messages");
        if (other.gameObject.CompareTag("Player") == true)
        {
            UnityEngine.Debug.Log("Trigger dialogue");
            trigger.StartDialogue();
        }
    }
}
