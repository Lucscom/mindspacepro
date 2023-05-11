using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchColor : MonoBehaviour
{
    int count = 0;
    Color red = new Color(0.8f,0f,0f,1f);
    Color green = new Color(0f,0.8f,0f,1f);
    Color blue = new Color(0f,0f,0.8f,1f);
    string currentColor = "red";

    void Update()
    {
     if (++count > 200) {
        count = 0;
        if (currentColor == "red") {
            currentColor = "green";
            GetComponent<Renderer>().material.SetColor("_Color",green);
        }
        else {
            currentColor = "red";
            GetComponent<Renderer>().material.SetColor("_Color",red);
        }
     }   
    }

}
