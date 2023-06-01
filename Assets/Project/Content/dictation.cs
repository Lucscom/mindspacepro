using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.Windows.Speech;
using TMPro;

public class dictation : MonoBehaviour
{
    private DictationRecognizer dictationRecognizer;

    //private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();

    void Start()
    {
        GetComponent<TextMeshPro>().text = "Click on the Micro to start Dictation";
        PhraseRecognitionSystem.Shutdown();

        dictationRecognizer = new DictationRecognizer();
        dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;

        dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;
        //dictationRecognizer.DictationComplete += DictationRecognizer_DictationComplete;
       // dictationRecognizer.DictationError += DictationRecognizer_DictationError;

        //dictationRecognizer.Start();
    }

    private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
    {
        // do something
        Debug.Log(text);
        GetComponent<TextMeshPro>().text = text;
    }

    private void DictationRecognizer_DictationHypothesis(string text)
    {
        // do something
        Debug.Log(text);
        GetComponent<TextMeshPro>().text = text;
    }
    private void DictationRecognizer_DictationComplete(DictationCompletionCause cause)
    {
        // do something
    }
    private void DictationRecognizer_DictationError(string error, int hresult)
    {
        // do something
    }
    private void Enddictation()
    {
        dictationRecognizer.DictationResult -= DictationRecognizer_DictationResult;
        dictationRecognizer.DictationComplete -= DictationRecognizer_DictationComplete;
        dictationRecognizer.DictationHypothesis -= DictationRecognizer_DictationHypothesis;
        dictationRecognizer.DictationError -= DictationRecognizer_DictationError;
        dictationRecognizer.Dispose();
    }

    public void Click()
    {
        Debug.Log("Start Recognization");
        dictationRecognizer.Start();

    }
    public void DictationStop()
    {
        Debug.Log("Stop Recognization");
        dictationRecognizer.Stop();

    }
}


















