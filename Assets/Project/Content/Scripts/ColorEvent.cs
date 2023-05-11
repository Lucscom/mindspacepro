using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setRed(){
        GetComponent<Renderer>().material.SetColor("_Color", new Color(0.8f, 0f, 0f, 1f));
    }

    public void setGreen(){
        GetComponent<Renderer>().material.SetColor("_Color", new Color(0f, 0.8f, 0f, 1f));
    }
}
