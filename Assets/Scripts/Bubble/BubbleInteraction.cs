using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleInteraction : MonoBehaviour
{
    float bubbleScaleMin = 0.04f;
    float bubbleScaleMax = .2f;

    public GameObject bubble;
    public float expantionSpeed = .2f;
    private void Start()
    {
        bubble.SetActive(false);
    }

    private void Update()
    {
        InteractBubble();
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
}
