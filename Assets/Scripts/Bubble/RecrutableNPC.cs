using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RecrutableNPC : InteractableBubbleItem
{
    public bool isFollowing = false;
    public int arrayIndex;
    public float offset = 1f;
    public Transform target = null;
    public float moveSpeed = 5f;
    public CircleCollider2D colliderCircle;

    public AudioSource audiosource;
    public AudioClip helloSound;

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        colliderCircle = GetComponent<CircleCollider2D>();
    }

    //public override void Interaction()
    //{
    //    base.Interaction();

    //    if (!isFollowing)
    //        isFollowing = true;
    //}

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            direction.Normalize();
            movement = direction;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //audiosource.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
           // audiosource.PlayOneShot(helloSound);

            if (!isFollowing)
            {
                audiosource.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
                audiosource.PlayOneShot(helloSound);
            }
            else if (isFollowing)
            {
                colliderCircle.enabled = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isFollowing)
        {
            FollowTarget(movement);
        }
    }

    void FollowTarget(Vector2 direction)
    {
        if (Vector2.Distance(target.position, transform.position) >= offset)
        {
            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        }
    }
}
