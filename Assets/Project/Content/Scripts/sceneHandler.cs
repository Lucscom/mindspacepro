using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;


/// <summary>
/// The sceneHandler is used to handle the scene. It is used to spawn new ToolTips, switch between edit and view mode and to handle the dictation.
/// </summary>
public class sceneHandler : MonoBehaviour
{   
        /// <summary>
        /// The baseTooltip is the ToolTip that is copied when the spawnObject function is called.
        /// </summary>
        public GameObject baseTooltip;

        /// <summary>
        /// The newObject is the ToolTip that is spawned when the spawnObject function is called.
        /// </summary>
        private GameObject newObject;

        /// <summary>
        /// The cameraObject is the Main Camera of the scene.
        /// </summary>
        public GameObject cameraObject;

        /// <summary>
        /// The toolTipList is a list of all ToolTips in the scene.
        /// </summary>
        public List<GameObject> toolTipList;
        
        /// <summary>
        /// The garbage is the GameObject that is used to delete ToolTips.
        /// </summary>
        public GameObject garbage;

        /// <summary>
        /// The showEdit is used to determine if the scene is in edit or view mode.
        /// </summary>
        private bool showEdit;
        private bool textInputChanged;

        /// <summary>
        /// The dictationRecognizer is used to handle the dictation.
        /// </summary>
        private DictationRecognizer dictationRecognizer;



    void Start()
    {
        // Dictation components
        PhraseRecognitionSystem.Shutdown();

        dictationRecognizer = new DictationRecognizer();
        dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;
        dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;

        // init list
        toolTipList = new List<GameObject>();

        // init showEdit
        showEdit = true;
        switchEdit();
        
    }

    /// <summary>
    /// This function is to spawn a new ToolTip.
    /// </summary>
    public void spawnObject()
    {
        // switch of all rec symbols
        foreach (GameObject toolTip in toolTipList)
        {
            toolTip.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }

        // start dictation
        dictationRecognizer.Start();

        // spawn new object in front of camera
        GameObject spawnPos = new GameObject();
        spawnPos.transform.position = cameraObject.transform.position;
        spawnPos.transform.rotation = cameraObject.transform.rotation;
        spawnPos.transform.position += spawnPos.transform.forward * 0.5f;

        // copy baseToolTip and setting it up
        newObject = Instantiate(baseTooltip, spawnPos.transform.position, spawnPos.transform.rotation);
        newObject.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().ToolTipText = "Dictate your text here";
        textInputChanged = true;
        newObject.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().ShowConnector = false;
        newObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(showEdit);

        newObject.SetActive(true);

        toolTipList.Add(newObject);
         
    }

    /// <summary>
    /// This function set the text of the ToolTip if the dictation is finished.
    /// </summary>
    private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        newObject.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().ToolTipText = text;  
        textInputChanged = true;
    }

    /// <summary>
    /// This function is called when the dictation is in progress and updated the text of the ToolTip.
    /// </summary>
    private void DictationRecognizer_DictationHypothesis(string text)
    {
        newObject.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().ToolTipText = text;
        textInputChanged = true;
    }

    /// <summary>
    /// This function stop the dictation and hide the rec symbol.
    /// </summary>
    public void stopDictation()
    {
        dictationRecognizer.Stop();
        newObject.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.SetActive(false);
        newObject = null;
    }

    /// <summary>
    /// This function is used to switch between edit and view mode.
    /// </summary>
    public void switchEdit()
    {
        showEdit = !showEdit;
        if (toolTipList.Count > 0)
        {   
            // switch all grabber symbols
            foreach (GameObject toolTip in toolTipList)
            {
                toolTip.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(showEdit);
            }
        }

        // switch garbage and change position of garbage
        garbage.SetActive(showEdit);

        if(showEdit == true)
        {
            Vector3 garbagePos = cameraObject.transform.position;
            garbagePos += new Vector3(-0.5f, -0.8f, -0.5f);
            garbage.transform.position = garbagePos;
            garbage.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    void Update() {
        
        // update size of collider
        if(textInputChanged)
        {
            newObject.GetComponent<BoxCollider>().size = new Vector3(newObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).transform.localScale.x * 2.18f, newObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).transform.localScale.y * 2.18f, 0.1f);
            textInputChanged = false;
        }
        
    }

}
