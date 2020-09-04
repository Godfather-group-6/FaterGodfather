﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;
using DG.Tweening;

public class NPCHammering : MonoBehaviour
{
    public Transform sorryExitPosition;

    CircleCollider2D circleCollider;
    
    [SerializeField]
    public bool interactable;

    [SerializeField]
    public bool alive = true;
    
    public GameObject healthBar;
    public Slider healthBarSlider;

    public GameObject bully;
    Player player;
    BubbleInteraction bubbleInteraction;
    public int peopleAmountNeeded = 1;

    public AudioSource soundSource;
    public AudioClip ouchSound;

    

    float health = 10f;
    float maxHealth = 10f;

    void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        healthBar.SetActive(false);
        healthBarSlider.value = maxHealth;
        healthBarSlider.maxValue = maxHealth;

        player = ReInput.players.GetPlayer(0);
        bubbleInteraction = GameObject.Find("Hero").GetComponent<BubbleInteraction>();

    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(alive)
        {
            if(collision.CompareTag("Player"))
            {
                if (!healthBar.activeSelf)
                {
                    healthBar.SetActive(true);
                    interactable = true;
                }
                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(alive)
        {
            if(collision.CompareTag("Player"))
            {
                if (healthBar.activeSelf)
                {
                    healthBar.SetActive(false);
                    interactable = false;
                }
            }
        }
    }


    private void Update()
    {
        if(alive)
        {
            if(player.GetButtonDown("Hammering") && interactable)
            {
                if(bubbleInteraction.peopleHitCounter >= peopleAmountNeeded)
                {
                    LowerBar(1f);
                    soundSource.pitch = Random.Range(0.7f, 1.2f); ;
                    soundSource.PlayOneShot(ouchSound);

                }else 
                {
                    Debug.Log("Pas assez de personnes :(");
                }
            } 
            if(health > 0 && health < maxHealth)
                health += 0.009f;
                updateBar();
            {

            }
            if(health <= 0)
            {
                secondInteraction();
            }
        }
        
        if(alive && health <= 0) {
            alive = false;
        }
    }


// Lower health bar
    public void LowerBar(float damage)
    {
        health -= damage;
        updateBar();
    }

// Update health bar
    public void updateBar()
    {
        healthBarSlider.value = health;
    }


// Trigger second part of interaction
    void secondInteraction()
    {
        healthBar.SetActive(false);
        interactable = false;

        if(bully){
            NPCSad  npcSad =  bully.GetComponent<NPCSad>();
            npcSad.Helped();
        }
        //animation pour changer le sprite à ajouter
        DOVirtual.DelayedCall(1f, () =>
        {
            transform.DOMove(sorryExitPosition.position, 2f)
            .OnComplete(() => { Destroy(gameObject); });
        });
    }



}
