using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public GameObject NPC;
    List<GameObject> Pop = new List<GameObject>();
    public Transform[] Spawn;
    public Transform GoHere;
    public float NPCSpeed;
    bool Used;
    float timer;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bubble" && !collision.gameObject.activeSelf && !Used)
        {
            gameObject.GetComponent<Animation>().Play("PhoneFeedBack");
            gameObject.GetComponent<AudioSource>().Play();
            for (int i=0; i < Spawn.Length; i++)
            {
               GameObject Go= Instantiate(NPC, Spawn[i].position, transform.rotation);
                Pop.Add(Go);
            }
            Used = true;
            timer = 3;
        }
    }
    private void Update()
    {
        if (timer > 0)
        {
            foreach (GameObject go in Pop)
            {
                go.transform.position = Vector2.Lerp(go.transform.position, GoHere.position, NPCSpeed*Time.deltaTime);
              
            }
            timer -= Time.deltaTime;
        }
    }

}
