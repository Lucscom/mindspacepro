using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

/// <summary>
/// This script is used to controll the grabber sphere on the ToolTip.
/// </summary>
public class grabber : MonoBehaviour
{   
    /// <summary>
    /// The toolTip is the ToolTip that is currently connected to the grabber.
    /// </summary>
    public GameObject toolTip;

    /// <summary>
    /// The sceneHandler is the GameObject that contains the connection script and is used to connect the ToolTips.
    /// </summary>
    public GameObject sceneHandler;
    
    /// <summary>
    /// The line is the line that is drawn between the grabber and the ToolTip.
    /// </summary>
    public LineRenderer line;

    /// <summary>
    /// showLIne is used to determine if the line should be drawn or not.
    /// </summary>
    private bool showLine;

    private void Start()
    {
        // Set the line to the correct width and disable it.
        showLine = false;
        line.startWidth = 0.003f;
        line.endWidth = 0.003f;
    }

    /// <summary>
    /// This function is used to reset the grabber to the ToolTip.
    /// </summary>
    public void resetGrabber()
    {
        GetComponent<Renderer>().transform.position = toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().AttachPointPosition;
        GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        showLine = false;
    }

    /// <summary>
    /// This function is used to start the grabber and show the line.
    /// </summary>
    public void startGrabber()
    {
        showLine = true;
    }

    /// <summary>
    /// This function is used to detect the onTriggerEnter event and start the connection mode and transmit the ToolTip and the collider to the sceneHandler.
    /// </summary>
    private void OnTriggerEnter(Collider other) {


        if(other.gameObject != toolTip && other.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>() != null && showLine)
        {
            sceneHandler.GetComponent<connectHandler>().parentToolTip = toolTip;
            sceneHandler.GetComponent<connectHandler>().toolTip = other.gameObject;
            sceneHandler.GetComponent<connectHandler>().connectionMode = true;
            GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
        

    }

    /// <summary>
    /// This function is used to detect the onTriggerExit event and stop the connection mode and transmit null to the sceneHandler.
    /// </summary>
    private void OnTriggerExit(Collider other) {
        if(showLine){
            sceneHandler.GetComponent<connectHandler>().parentToolTip = null;
            sceneHandler.GetComponent<connectHandler>().toolTip = null;
            sceneHandler.GetComponent<connectHandler>().connectionMode = false;
            GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        }

    }

    /// <summary>
    /// This function is used to update the line and the position of the grabber.
    /// </summary>
    void Update()
    {
        if(showLine){
            line.enabled = true;
            Vector3 positionGrabber = ToolTipUtility.FindClosestAttachPointToAnchor(GetComponent<Renderer>().transform, toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().ContentParentTransform, toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().LocalAttachPointPositions, toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().PivotType);
            line.SetPosition(0, toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().ContentParentTransform.TransformPoint(positionGrabber));
            line.SetPosition(1, GetComponent<Renderer>().transform.position);

        }
        else{
            line.enabled = false;
            if(toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().LocalAttachPointPositions != null && toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().LocalAttachPointPositions.Length > 1)
            {
                GetComponent<Renderer>().transform.position = toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().ContentParentTransform.TransformPoint(toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().LocalAttachPointPositions[1]);
            }  
        }
    }

}
