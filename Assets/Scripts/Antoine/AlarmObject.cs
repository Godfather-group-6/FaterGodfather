﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class AlarmObject : MonoBehaviour
{

    CircleCollider2D circleCollider;
    public GameObject infoBubble;

    [HideInInspector]
    public bool interactable;

    [HideInInspector]
    public bool triggered;

    float min = 0.01f;
    public float rayon = 2f;

    List<GameObject> hostilesInRange = new List<GameObject>();
    Player player;



    void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        infoBubble.SetActive(false);
        player = ReInput.players.GetPlayer(0);

    }


    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !triggered)
        {
            if (!infoBubble.activeSelf)
            {
                infoBubble.SetActive(true);
                interactable = true;
            }
        }
        if(collision.CompareTag("NPCHostile"))
        {
            if(!hostilesInRange.Contains(collision.gameObject))
            {
                hostilesInRange.Add(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (infoBubble.activeSelf)
            {
                infoBubble.SetActive(false);
                interactable = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetButtonDown("Interact") && interactable && !triggered)
        {
            Debug.Log("Ding dong");
            triggered = true;
        }


        if(triggered && min<rayon)
        {
            min+=0.01f;
            triggerAlarmSound(min);
        }

        
        foreach (GameObject hostile in hostilesInRange) {
            if(hostile.GetComponent<AlarmResponse>() == null) 
            {
                Debug.Log("HOSTILE MISSING TARGET POSITION (AlarmResponse)");
                return;
            }
            Vector2 loc = hostile.GetComponent<AlarmResponse>().locTarget;
            float step =  2 * Time.deltaTime;
            hostile.transform.position = Vector3.MoveTowards(hostile.transform.position, loc, step);
            if(hostile.transform.position.x == loc.x && hostile.transform.position.y == loc.y)
            {
                Destroy(hostile);
                hostilesInRange.Remove(hostile);
                return;
            }
        }
        
    }

    void triggerAlarmSound(float size)
    {
        circleCollider.radius = size;
    }
}
