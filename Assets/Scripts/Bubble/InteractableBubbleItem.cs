using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableBubbleItem : NPCBehaviour
{
    public Image lifeBar;
    public float totalLifepoints = 3;
    float lifepoints;

    void Awake()
    {
        lifepoints = totalLifepoints;
        lifeBar.fillAmount = lifepoints / totalLifepoints;
    }

    void UpdateLife()
    {
        if (lifepoints <= 0)
        {
            lifepoints = 0;
            return;
        }

        lifepoints--;

        if(lifepoints == 0)
        {
            Interaction();
        }

        lifeBar.fillAmount = lifepoints / totalLifepoints;
    }

    private void Interaction()
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
            UpdateLife();
        }
    }
}
