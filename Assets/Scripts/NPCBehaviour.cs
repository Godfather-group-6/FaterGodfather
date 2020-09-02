using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class NPCBehaviour : MonoBehaviour
{
    CircleCollider2D circleCollider;

    public bool Interactable
    {
        set { Interactable = askIcon.activeSelf; }
    }
    public GameObject askIcon;
    public GameObject choicesPanel;

    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }
    private void Start()
    {
        askIcon.SetActive(false);
        choicesPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!askIcon.activeSelf)
            {
                askIcon.SetActive(true);
                choicesPanel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player exit");
            if (askIcon.activeSelf)
            {
                askIcon.SetActive(false);
                choicesPanel.SetActive(false);
            }
        }
    }
}
