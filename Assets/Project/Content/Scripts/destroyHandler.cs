using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to destroy the toolTip
/// </summary>
public class destroyHandler : MonoBehaviour
{
    /// <summary>
    /// sceneHandler object
    /// </summary>

    public GameObject sceneHandler;

    /// <summary>
    /// toolTip object
    /// </summary>
    public GameObject toolTip;

    /// <summary>
    /// destroyMode is used to check if the toolTip is in destroy mode. It is triggered by the collision Event in the garbage can
    /// </summary>
    public bool destroyMode;

    /// <summary>
    /// garbageMaterial is used to change the color of the garbage can when the toolTip is in destroy mode
    /// </summary>
    public Material garbageMaterial;
    

    void Start()
    {
        destroyMode = false;
        toolTip = null;
    }

    public void OnDestroy() 
    {
        if(toolTip != null && destroyMode == true){
            foreach (GameObject childToolTip in toolTip.GetComponent<connectToolTip>().childToolTips)
            {
                childToolTip.GetComponent<connectToolTip>().parentToolTip = null;
                childToolTip.GetComponent<connectToolTip>().isConnected = false;
                childToolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().ShowConnector = false;
            }

            if(toolTip.GetComponent<connectToolTip>().parentToolTip != null){
                toolTip.GetComponent<connectToolTip>().parentToolTip.GetComponent<connectToolTip>().childToolTips.Remove(toolTip);
            }
            sceneHandler.GetComponent<sceneHandler>().toolTipList.Remove(toolTip);

            Destroy(toolTip);

            garbageMaterial.SetColor("_Color", Color.gray);

        }

    }
    


}
