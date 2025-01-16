using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.WitAi.TTS.Integrations;
using Meta.WitAi.TTS.Utilities;
using Crosstales.RTVoice.Tool;

public class ChangeVoiceNPC : MonoBehaviour
{
    public bool isFemale = false;
    public GameObject male;
    public GameObject female;

    SpeechText speechText;

    // Start is called before the first frame update
    void Start()
    {
        speechText = FindObjectOfType<SpeechText>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeVoice(TTSSpeaker tTS)
    {
        if(!isFemale)
        {
            isFemale = true;
            //speechText.Voices.Gender = Crosstales.RTVoice.Model.Enum.Gender.FEMALE;
            tTS.presetVoiceID = "Rebecca";
            //male.SetActive(false);
            //female.SetActive(true);
            MeshActive(male, false);
            MeshActive(female, true);
        }
        else
        {
            isFemale = false;
            //speechText.Voices.Gender = Crosstales.RTVoice.Model.Enum.Gender.MALE;
            tTS.presetVoiceID = "Charlie";
            //female.SetActive(false);
            //male.SetActive(true);
            MeshActive(female, false);
            MeshActive(male, true);
        }
    }

    public void MeshActive(GameObject model, bool isActive)
    {
        SkinnedMeshRenderer[] skins = model.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer skin in skins)
        {
            skin.enabled = isActive;
        }
    }
}
