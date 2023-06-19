using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to detect if the ToolTip is in the destroy zone.
/// </summary>
public class destroyOnCollision : MonoBehaviour
{

    /// <summary>
    /// The sceneHandler is used to access the destroyHandler script.
    /// </summary>
    public GameObject sceneHandler;
    /// <summary>
    /// The garbageMaterial is used to change the color of the garbage.
    /// </summary>
    public Material garbageMaterial;

        private void Start() 
        {
            garbageMaterial.SetColor("_Color", Color.gray);
        }

        // detect if the ToolTip is in the destroy zone
        private void OnTriggerEnter(Collider other) 
        {
            if(other.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>() != null)
            {
                sceneHandler.GetComponent<destroyHandler>().toolTip = other.gameObject;
                sceneHandler.GetComponent<destroyHandler>().destroyMode = true;
                garbageMaterial.SetColor("_Color", Color.red);
            }
        }
        
        // detect if the toolTip exits the destroy zone
        private void OnTriggerExit(Collider other) 
        {

            sceneHandler.GetComponent<destroyHandler>().toolTip = null;
            sceneHandler.GetComponent<destroyHandler>().destroyMode = false;
            garbageMaterial.SetColor("_Color", Color.gray);
            
        }
}
