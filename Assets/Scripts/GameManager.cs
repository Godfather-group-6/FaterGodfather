using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public float Temps = 300;
    public TextMeshProUGUI Chrono;
    int NbrFollower = 1;
    float timer;
    public string endsceneName = "EndMenu";

 public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        timer = Temps;
    }
    private void Start()
    {
        foreach (NPCSad NS in Resources.FindObjectsOfTypeAll(typeof(NPCSad)))
        {
            NS.peopleAmountText.GetComponent<TextMeshProUGUI>().text = NbrFollower + "/" + NS.peopleAmountNeeded;
        }
    }
    private void FixedUpdate()
    {
        GameTimer();
   
    }

    public void UpdateFollower(bool Plus)
    {
        if (Plus)
        {
            NbrFollower++;
        }
        else if (NbrFollower>0)
        {
            NbrFollower--;
        }
        foreach (NPCSad NS in Resources.FindObjectsOfTypeAll(typeof(NPCSad)))
        {
           NS.peopleAmountText.GetComponent<TextMeshProUGUI>().text =  NbrFollower+ " / " + NS.peopleAmountNeeded;
        }
        foreach (NPCHammering NH in Resources.FindObjectsOfTypeAll(typeof(NPCHammering)))
        {
            //quand il y aura l'indicateur
        }
    }
    void GameTimer()
    {
        
        timer = Temps - Time.timeSinceLevelLoad;;

        string minutes = ((int) timer / 60).ToString();
        string seconds = (timer % 60).ToString("f0");

        Chrono.text = minutes + ":" + seconds;

        if(timer <= 0)
        {
            EndGame();
        }
    }
    void EndGame()
    {
        SceneManager.LoadScene(endsceneName);
    }


    public void doExitGame()
    {
        Application.Quit();
    }
    public void MyLoadScene(string nameScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nameScene);
     
    }
}
