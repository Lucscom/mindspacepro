using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

/// <summary>
/// This class manage the rec symbol on the ToolTip if a recording is active.
/// </summary>
public class recHandler : MonoBehaviour
{   
    /// <summary>
    /// The fpsCounter is used to change the update time of the rec symbol.
    /// </summary>
    private int fpsCounter;

    /// <summary>
    /// The sphereActive is used to change the visibility of the rec symbol.
    /// </summary>
    private bool sphereActive = true;

    /// <summary>
    /// The toolTip is the ToolTip where the rec symbol is attached to.
    /// </summary>
    public GameObject toolTip;

    void Update()
    {
        // set the position of the rec symbol
        if(toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().LocalAttachPointPositions != null && toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().LocalAttachPointPositions.Length > 1)
        {
            GetComponent<Renderer>().transform.position = toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().ContentParentTransform.TransformPoint(toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().LocalAttachPointPositions[0]);;
            GetComponent<Renderer>().transform.rotation = toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().ContentParentTransform.rotation;
        }  

        // update the rec symbol
        fpsCounter ++;

        if(fpsCounter >= 30)
            fpsCounter = 0;

        if(fpsCounter == 0)
        {
            GetComponent<Renderer>().gameObject.transform.GetChild(0).gameObject.SetActive(sphereActive);
            sphereActive = !sphereActive;
        }

    }
}
