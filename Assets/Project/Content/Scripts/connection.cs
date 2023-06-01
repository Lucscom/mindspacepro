using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class connection : MonoBehaviour
{
    public GameObject parentToolTip;
    private GameObject toolTipSphere;
    public GameObject toolTip;
    private bool connectionMode;

    void Start()
    {
        connectionMode = false;
        parentToolTip = null;
    }
    void Update()
    {
        
    }

    public void settoolTip(GameObject _toolTip)
    {
        toolTip = _toolTip;
    }
    public void setToolTipSphere(GameObject _sphere)
    {
        toolTipSphere = _sphere;
    }

    public void setConnectionMode(bool _connectionMode)
    {
        connectionMode = _connectionMode;
    }

    public void connect() 
    {
        if (connectionMode == true && toolTip != parentToolTip && toolTip != null && parentToolTip != null) 
        {
            toolTip.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().ShowConnector = true;
            toolTipSphere.GetComponent<grabber>().parentToolTip = parentToolTip;
            toolTipSphere.GetComponent<grabber>().isConnected = true;
            connectionMode = false;
            toolTip = null;
            parentToolTip = null;
        }
    }
    

}
