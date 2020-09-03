using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RecrutableNPC : InteractableBubbleItem
{
    public bool isFollowing = false;
    public int arrayIndex;
    public float offset = 2f;
    public Transform target = null;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

    private void FixedUpdate()
    {
        if (isFollowing)
        {
            FollowTarget(movement);
        }
    }

    void FollowTarget(Vector2 direction)
    {
        if (Vector2.Distance(target.position, transform.position) >= 3)
        {
            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        }
    }
}
