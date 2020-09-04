using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class NPCSad : MonoBehaviour
{
    public string npcText = "Oh i'm so sad, I need happiness !";
    public string npcThankText = "Thanks, I'll remember that !";

    public float waitTimeBeforeLeaving = 1f;
    public float moveSpeed = 5f;

    public int peopleAmountNeeded = 1;
    public GameObject descriptionText;
    public GameObject peopleAmountText;
    public bool happy;
    public bool isInTrouble = false;

    public SpriteRenderer charSpriteRenderer;

    public Sprite happySprite;
    public Sprite sadSprite;
    //public bool interactable;

    public Transform happyExitPosition = null;

    public GameObject infoBubble;

    //BubbleInteraction bubbleInteraction;
    TextMeshProUGUI TMP_Text;
    TextMeshProUGUI peopleTMP_Text;

    [SerializeField] private Animator animator;

    [SerializeField] private GameObject shineParticle;
    [SerializeField] private GameObject sadParticle;


    void Start()
    {
        //bubbleInteraction = GameObject.Find("Hero").GetComponent<BubbleInteraction>();

        shineParticle.SetActive(false);
        sadParticle.SetActive(true);


        TMP_Text = descriptionText.GetComponent<TextMeshProUGUI>();
        peopleTMP_Text = peopleAmountText.GetComponent<TextMeshProUGUI>();

        infoBubble.SetActive(false);
        if (!isInTrouble)
        {
            TMP_Text.text = npcText;
            peopleAmountText.SetActive(true);
        }
        else
        {
            peopleAmountText.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !happy)
        {
            if (!infoBubble.activeSelf)
            {
                infoBubble.SetActive(true);
                //interactable = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !happy)
        {
            if (infoBubble.activeSelf)
            {
                infoBubble.SetActive(false);
                //interactable = false;
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

    public void Helped()
    {
        shineParticle.SetActive(true);
        sadParticle.SetActive(false);
        //interactable = false;
        happy = true;
        charSpriteRenderer.sprite = happySprite;
        TMP_Text.text = npcThankText;

        HelpManager.instance.personHelped();

        Debug.Log("LANCER ANIM HEUREUX");
        animator.SetTrigger("IdleTrans");
        if (happyExitPosition != null)
        {
            ExitLeaving();
        }
        else
            Destroy(gameObject);
    }

    void ExitLeaving()
    {
        charSpriteRenderer.sprite = happySprite;
        DOVirtual.DelayedCall(waitTimeBeforeLeaving, () =>
        {
            infoBubble.SetActive(false);
            transform.DOMove(happyExitPosition.position, 2f)
            .OnComplete(() => { Destroy(gameObject); });
        });
    }

}
