using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpManager : MonoBehaviour
{
    public static HelpManager instance;

    public int characteresHelped = 0;


    void Awake(){
        instance = this;
    }

    public void personHelped() 
    {
        characteresHelped++;
    }
}
