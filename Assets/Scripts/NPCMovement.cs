using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float Speed;
    public float IdleTime;
    public Transform[] WayPoints;
    int CurrentWaypoint = 0;
    float timer;


    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else{
            transform.position = Vector2.MoveTowards(transform.position, WayPoints[CurrentWaypoint].position, Speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, WayPoints[CurrentWaypoint].position) < 0.5)
            {

                if (CurrentWaypoint < WayPoints.Length - 1)
                {
                    CurrentWaypoint++;

                }
                else
                {
                    CurrentWaypoint = 0;
                }
                timer = IdleTime;
            }
        }
        
            
        
    }
}
