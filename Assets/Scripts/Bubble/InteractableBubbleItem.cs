using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableBubbleItem : NPCBehaviour
{
    public virtual void Interaction()
    {
        choicesPanel.SetActive(false);
        askIcon.SetActive(false);
        Debug.Log("Interaction with " + name);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player exit");
            if (askIcon.activeSelf)
            {
                askIcon.SetActive(false);
                choicesPanel.SetActive(false);
            }
        }
        if (collision.gameObject.tag == "Bubble" && !collision.gameObject.activeSelf)
        {
            Interaction();
        }
    }
}
