using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCHammering : MonoBehaviour
{

    CircleCollider2D circleCollider;
    
    [SerializeField]
    public bool interactable;

    [SerializeField]
    public bool alive = true;
    
    public GameObject healthBar;
    public Slider healthBarSlider;
    

    float health = 10f;
    float maxHealth = 10f;


    void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        healthBar.SetActive(false);
        healthBarSlider.value = health;
        healthBarSlider.maxValue = maxHealth;
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
            if(Input.GetKeyDown("space") && interactable)
            {
                LowerBar(1f);
            }

            if(health > 0 && health < maxHealth)
                health += 0.001f;
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
        Debug.Log("Oh, une interaction !");
    }



}
