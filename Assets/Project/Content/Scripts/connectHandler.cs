using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class connectHandler : MonoBehaviour
{
    /// <summary>
    /// The parentToolTip is the ToolTip where the grabber is attached to.
    /// </summary>
    public GameObject parentToolTip;

    /// <summary>
    /// The toolTip is the ToolTip where the grabber collides with.
    /// </summary>
    public GameObject toolTip;

    /// <summary>
    /// The connectionMode is used to determine if the grabber is in connection mode or not.
    /// </summary>
    public bool connectionMode;


    void Start()
    {   
        // reset Objects
        connectionMode = false;
        parentToolTip = null;
        toolTip = null;
    }

    /// <summary>
    /// This function is triggered when the grabber manipulation is ended and the connection mode is active.
    /// </summary>
    public void connect() 
    {
        if (connectionMode == true && toolTip != parentToolTip && toolTip != null && parentToolTip != null) 
        {   
            toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().ShowConnector = true; 
            toolTip.GetComponent<connectToolTip>().parentToolTip = parentToolTip;
            toolTip.GetComponent<connectToolTip>().isConnected = true;

            parentToolTip.GetComponent<connectToolTip>().childToolTips.Add(toolTip);

            connectionMode = false;
        }
    }
    

}
