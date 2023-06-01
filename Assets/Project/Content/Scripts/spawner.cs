using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject spawnee;
    public Transform spawnPos;
    private GameObject newObject; 
    

    public void spawnObject()
    {   
        newObject = Instantiate(spawnee, spawnPos.position, spawnPos.rotation);
        newObject.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().ShowConnector = false;
        newObject.SetActive(true);
        
    }
    // Update is called once per frame

}
