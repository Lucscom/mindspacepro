using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject spawnee;
    public Transform posAnchor;
    public GameObject Anchor;
    

    public void spawnObject()
    {
        Instantiate(spawnee, spawnPos.position, spawnPos.rotation);  
        Anchor.transform.position = posAnchor.position;

    }

    // Update is called once per frame

}
