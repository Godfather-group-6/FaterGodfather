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

    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer charSprite;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();

        player = ReInput.players.GetPlayer(0);

    }

    private void Update()
    {
        Move();
    }

    void FixedUpdate()
    {
        if(!player.GetButton("Buble")) 
        {
            rb.velocity = new Vector2(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime);
        } else {
            rb.velocity = new Vector2(0,0);
        }
        

    }

    void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal < 0)
        {
            animator.SetTrigger("IsRunningSide");
            charSprite.flipX = false;
        }
        else if (horizontal > 0)
        {
            animator.SetTrigger("IsRunningSide");
            charSprite.flipX = true;
        }
        else if (vertical > 0)
        {
            animator.SetTrigger("IsRunningBack");
        }
        else if (vertical < 0)
        {
            animator.SetTrigger("IsRunningFront");
        }
        else
        {
            animator.SetTrigger("Idle");
        }
    }
}
