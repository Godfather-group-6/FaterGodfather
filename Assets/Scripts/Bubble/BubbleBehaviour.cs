using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBehaviour : MonoBehaviour
{
    [SerializeField] private BubbleInteraction bubbleInteraction;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Recrutable")
        {
            bubbleInteraction.recrutables.Add(collision.gameObject.GetComponent<RecrutableNPC>());
        }
    }
}
