using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

/// <summary>
/// This script is used to connect the ToolTips. It is attached to the ToolTip.
/// </summary>
public class connectToolTip : MonoBehaviour
{
    /// <summary>
    /// The parentToolTip is the ToolTip that is currently connected to the ToolTip.
    /// </summary>
    public GameObject parentToolTip;

    /// <summary>
    /// The toolTip is the Object where the script is attached to.
    /// </summary>
    public GameObject toolTip;

    /// <summary>
    /// The targetObject is used to connect the ToolTip Target because the Target need to be a GameObject.
    /// </summary>
    public GameObject targetObject;

    /// <summary>
    /// isConnected is used to determine if the ToolTip is connected to another ToolTip.
    /// </summary>
    public bool isConnected;

    public List<GameObject> childToolTips;


    void Start()
    {
        isConnected = false;

        childToolTips = new List<GameObject>();
    }

    /// <summary>
    /// This function is used to update the position of the ToolTip and the ToolTipConnector.
    /// </summary>
    void Update()
    {
        // if the ToolTip is connected to another ToolTip, the ToolTipConnector is updated
        if(isConnected){
            Vector3 positionParent = ToolTipUtility.FindClosestAttachPointToAnchor(toolTip.transform, parentToolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().ContentParentTransform, parentToolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().LocalAttachPointPositions, toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().PivotType);
            targetObject.transform.position = parentToolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().ContentParentTransform.TransformPoint(positionParent);
            toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTipConnector>().Target = targetObject;
        }
        else{
            toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTipConnector>().Target = null;
        }
        
    }
}
