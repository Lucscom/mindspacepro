using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public enum direc {
        links,
        rechts
    };

    public direc Richtung; 


    // Update is called once per frame
    void Update()
    {
        if (Richtung == direc.links) transform.Rotate(0f,-0.2f,0f, Space.Self);
        else transform.Rotate(0f,0.2f,0f, Space.Self);
    }

}
