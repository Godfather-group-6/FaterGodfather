﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;


public class BubbleInteraction : MonoBehaviour
{
    public float bubbleScaleMin = 0.04f;
    public float bubbleScaleMax = .2f;

    public List<RecrutableNPC> recrutables = new List<RecrutableNPC>();
    Player player;


    public int peopleHitCounter = 1;

    public GameObject bubble;
    public float expantionSpeed = 2f;
    private void Start()
    {
        bubble.SetActive(false);
        player = ReInput.players.GetPlayer(0);

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

    public void InteractBubble()
    {

        if (player.GetButtonDown("Buble") && !bubble.activeSelf)
        {
            bubble.SetActive(true);
            bubble.transform.localScale = Vector3.one * bubbleScaleMin;
        }

        if (player.GetButton("Buble") && bubble.activeSelf)
        {
            if (bubble.transform.localScale.x >= bubbleScaleMax)
                bubble.transform.localScale = Vector3.one * bubbleScaleMax;
            else
                bubble.transform.localScale += Vector3.one * expantionSpeed * Time.deltaTime;

        }

        if (player.GetButtonUp("Buble") && bubble.activeSelf)
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

    public void DispatchFollowers()
    {
        peopleHitCounter = 1;
        foreach (RecrutableNPC recrutableNPC in recrutables)
        {
            recrutableNPC.isFollowing = false;
            recrutableNPC.target = null;
            Destroy(recrutableNPC.gameObject);
        }
        recrutables.Clear();
    }
}
