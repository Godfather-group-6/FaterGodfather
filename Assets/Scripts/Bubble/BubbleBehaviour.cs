using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBehaviour : MonoBehaviour
{
    [SerializeField] private BubbleInteraction bubbleInteraction;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.activeSelf)
            return;

        if (collision.gameObject.tag == "Recrutable")
        {

            if (!collision.gameObject.GetComponent<RecrutableNPC>().isFollowing)
            {
                bubbleInteraction.recrutables.Add(collision.gameObject.GetComponent<RecrutableNPC>());
                bubbleInteraction.UpdateRecrutableList();
            }
        }
        else if (collision.gameObject.tag == "NPCSad")
        {
            if (collision.gameObject.GetComponent<NPCSad>().isInTrouble)
                return;

            if (bubbleInteraction.peopleHitCounter >= collision.gameObject.GetComponent<NPCSad>().peopleAmountNeeded)
            {
                collision.gameObject.GetComponent<NPCSad>().Helped();
            }
            else
            {
                Debug.Log("Pas assez de personnes :(");
            }
        }
    }
}
