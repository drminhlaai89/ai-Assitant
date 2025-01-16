using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SeasonEventCatalog : MonoBehaviour
{
    public GameObject[] seasonEffect;
    public Animator animBG;
    public TMP_Text seasonSelect;

    public void OnClickSeason(GameObject seasonObj)
    {
        for(int i =0; i< seasonEffect.Length; i++)
        {
            seasonEffect[i].SetActive(false);
        }
        seasonObj.SetActive(true);
    }

    public void PlayAnimationSeason(string seasonName)
    {
        seasonSelect.text = seasonName;
        animBG.Play(seasonName);
    }
    
}
