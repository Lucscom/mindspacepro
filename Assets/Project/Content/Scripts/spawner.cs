using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Windows.Speech;


public class spawner : MonoBehaviour
{
    public GameObject spawnee;
    public Transform spawnPos;
    private GameObject newObject;
    private DictationRecognizer dictationRecognizer;

    void Start()
    {
        PhraseRecognitionSystem.Shutdown();

        dictationRecognizer = new DictationRecognizer();
        dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;

        //dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;
        //dictationRecognizer.DictationComplete += DictationRecognizer_DictationComplete;
        // dictationRecognizer.DictationError += DictationRecognizer_DictationError;

        //dictationRecognizer.Start();
    }

    public void spawnObject()
    {
        dictationRecognizer.Start();
        newObject = Instantiate(spawnee, spawnPos.position, spawnPos.rotation);
        newObject.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().ShowConnector = false;
       // newObject.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().ToolTipText = "Test to see";
        newObject.SetActive(true);
        

    }
    // Update is called once per frame

    private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        // do something
        Debug.Log(text);
        newObject.GetComponent<Microsoft.MixedReality.Toolkit.UI.ToolTip>().ToolTipText = text;
        dictationRecognizer.Stop();
    }

}



