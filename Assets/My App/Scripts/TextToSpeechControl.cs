using Meta.WitAi.TTS.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextToSpeechControl : MonoBehaviour
{
    public TTSSpeaker speaker;
    [SerializeField] private TMP_Text textInput;
    //[SerializeField] private Button sendButton;

    private void Awake()
    {

    }

    public void TextToSpeech()
    {
        if(!string.IsNullOrEmpty(textInput.text))
        {
            speaker.Speak(textInput.text);
            
        }
        else
        {
            Debug.Log("Empty cant speak");
        }
    }

    public void TextToSpeech_2(string[] textChunks)
    {
        if (textChunks.Length > 0)
        {
            StartCoroutine(speaker.SpeakQueuedAsync(textChunks));
        }
        else
        {
            Debug.Log("Empty cant speak");
        }
    }

    public void StopSpeak()
    {
        speaker.Stop();
    }
}
