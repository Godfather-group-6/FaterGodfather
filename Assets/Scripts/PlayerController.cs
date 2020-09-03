using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    CircleCollider2D circleCollider;

    Player player;

    float horizontal;
    float vertical;
    public float speed = 200.0f;
    private Vector2 inputVector = Vector2.zero;
    private BubbleInteraction bubbleInteraction;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();

        player = ReInput.players.GetPlayer(0);

    }

    void FixedUpdate()
    {
        Move();
        if(!player.GetButton("Buble")) 
        {
            rb.velocity = new Vector2(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime);
        } else {
            rb.velocity = new Vector2(0,0);
        }
        

    }

    void Move()
    {
        horizontal = player.GetAxis("Move Horizontal");
        vertical = player.GetAxis("Move Vertical");
    }
}
