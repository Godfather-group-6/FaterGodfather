using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleInteraction : MonoBehaviour
{
    public float bubbleScaleMin = 0.04f;
    public float bubbleScaleMax = .2f;

    public List<RecrutableNPC> recrutables = new List<RecrutableNPC>();

    public int peopleHitCounter = 1;

    public GameObject bubble;
    public float expantionSpeed = 2f;
    private void Start()
    {
        bubble.SetActive(false);
    }

    private void Update()
    {
        InteractBubble();

        if (peopleHitCounter > 1)
            StopFollowers();
    }

    public void UpdateRecrutableList()
    {
        for (int i = 0; i < recrutables.Count; i++)
        {
            if (i == 0)
                recrutables[i].target = transform;
            else
                recrutables[i].target = recrutables[i - 1].transform;

            if (!recrutables[i].isFollowing)
                recrutables[i].isFollowing = true;
        }

        peopleHitCounter = 1 + recrutables.Count;
    }

    void InteractBubble()
    {

        if (Input.GetKeyDown(KeyCode.J) && !bubble.activeSelf)
        {
            bubble.SetActive(true);
            bubble.transform.localScale = Vector3.one * bubbleScaleMin;
        }

        if (Input.GetKey(KeyCode.J) && bubble.activeSelf)
        {
            if (bubble.transform.localScale.x >= bubbleScaleMax)
                bubble.transform.localScale = Vector3.one * bubbleScaleMax;
            else
                bubble.transform.localScale += Vector3.one * expantionSpeed * Time.deltaTime;

        }

        if (Input.GetKeyUp(KeyCode.J) && bubble.activeSelf)
        {
            bubble.transform.localScale = Vector3.one * bubbleScaleMin;
            bubble.SetActive(false);
        }
    }

    void StopFollowers()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            peopleHitCounter = 1;
            foreach (RecrutableNPC recrutableNPC in recrutables)
            {
                recrutableNPC.isFollowing = false;
                recrutableNPC.target = null;
            }
            recrutables.Clear();
        }
    }
}
