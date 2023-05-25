using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject spawnee;
    public GameObject posAnchor;
    public GameObject Anchor;
    GameObject schild;


    public void spawnObject()
    {
        schild = Instantiate(spawnee, spawnPos.position, spawnPos.rotation);
        schild.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTipConnector>().Target = posAnchor;
    }

    // Update is called once per frame

}
