using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class grabber : MonoBehaviour
{   
    public GameObject toolTip;
    public GameObject parentToolTip;
    public GameObject sceneHandler;
    public GameObject targetObject;
    public bool isConnected;
    


    public LineRenderer line;
    private bool showLine;

    private void Start()
    {
        GetComponent<Renderer>().transform.position = toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().AttachPointPosition;
        showLine = false;
        isConnected = false;
        //line.startColor = Color.white;
        //line.endColor = Color.white;
        line.startWidth = 0.003f;
        line.endWidth = 0.003f;
    }
    
    public void resetGrabber()
    {
        GetComponent<Renderer>().transform.position = toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().AttachPointPosition;
        showLine = false;
    }

    public void startGrabber()
    {
        showLine = true;
        sceneHandler.GetComponent<connection>().parentToolTip = toolTip;
    }

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
            if(toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().LocalAttachPointPositions != null)
            {
                GetComponent<Renderer>().transform.position = toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().ContentParentTransform.TransformPoint(toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().LocalAttachPointPositions[1]);
            }
            
        }
        if(isConnected){
            Vector3 positionParent = ToolTipUtility.FindClosestAttachPointToAnchor(toolTip.transform, parentToolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().ContentParentTransform, parentToolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().LocalAttachPointPositions, toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().PivotType);
            targetObject.transform.position = parentToolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().ContentParentTransform.TransformPoint(positionParent);
            toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTipConnector>().Target = targetObject;
        }

    }

}
