using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCSad : MonoBehaviour
{
    public int peopleAmountNeeded = 1;
    public GameObject peopleAmountText;
    public bool happy;
    public bool isInTrouble = false;
    //public bool interactable;

    CircleCollider2D circleCollider;
    public GameObject infoBubble;
    
    //BubbleInteraction bubbleInteraction;
    TextMeshProUGUI TMP_Text;


    void awake() {
        
        //bubbleInteraction = GameObject.Find("Hero").GetComponent<BubbleInteraction>();
        
        TMP_Text = peopleAmountText.GetComponent<TextMeshProUGUI>();

        if(!isInTrouble)
        {
            TMP_Text.text = peopleAmountNeeded + "x ";
            infoBubble.SetActive(false);
        } else {
            TMP_Text.text = "";
            infoBubble.SetActive(false);
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(!isInTrouble)
        {
            if(collision.CompareTag("Player") && !happy)
            {
                if (!infoBubble.activeSelf)
                {
                    infoBubble.SetActive(true);
                    //interactable = true;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!isInTrouble)
        {
            if(collision.CompareTag("Player") && !happy)
            {
                if (infoBubble.activeSelf)
                {
                    infoBubble.SetActive(false);
                    //interactable = false;
                }
            }
        }
    }

    //private void Update() {
    //    if(Input.GetKeyDown("e") && interactable){
    //        if(peopleAmountNeeded<=bubbleInteraction.peopleHitCounter) {
    //            Helped();
    //        } else {
    //            Debug.Log("Pas assez de personnes :(");
    //        }
    //    }
    //}

    public void Helped() {
        
        if(!isInTrouble)
        {
            infoBubble.SetActive(false);
            //interactable = false;
            happy = true;
            TMP_Text.text = "";
        }

        HelpManager.instance.personHelped();

        Debug.Log("LANCER ANIM HEUREUX");
    }

}
