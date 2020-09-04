using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelpManager : MonoBehaviour
{
    public static HelpManager instance;
    public TextMeshProUGUI scoreCounterText; 

    public int characteresHelped = 0;


    void Awake(){
        instance = this;
        scoreCounterText.text = ""+characteresHelped;
    }

    public void personHelped() 
    {
        characteresHelped++;
        scoreCounterText.text = ""+characteresHelped;
    }
}
