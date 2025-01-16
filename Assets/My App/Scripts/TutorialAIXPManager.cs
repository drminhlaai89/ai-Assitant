using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TutorialAIXPManager : MonoBehaviour
{
    public GameObject chatTutorial;
    public GameObject placeTeleport;
    public GameObject triggerNPC;
    public GameObject exitText;
    public GameObject nextText;
    public GameObject holoObj;
    public TMP_Text janTalk;

    public Button[] buttons;
    public GameObject[] stepTutorials;

    public Color32 oldColor;
    public Color32 newColor;

    public int checkPlayerInt;
    public int a = 1;

    HandWritingEffect handWritingEffect;
    SaveAndLoadImageManager saveAndLoadImageManager;
    WristMenu wristMenu;

    private void Awake()
    {
        handWritingEffect = FindObjectOfType<HandWritingEffect>();
        saveAndLoadImageManager = FindObjectOfType<SaveAndLoadImageManager>();
        wristMenu = FindObjectOfType<WristMenu>();
    }
    private void Start()
    {
        CheckPlayer();
        handWritingEffect.RevealText2(janTalk);
        oldColor = new Color32(207, 207, 207, 255);
        newColor = new Color32(99, 99, 99, 255);
    }

    public void OnClickSave()
    {
        checkPlayerInt = 1;
        PlayerPrefs.SetInt("FirstTime", checkPlayerInt);
        PlayerPrefs.Save();
        triggerNPC.SetActive(true);
        chatTutorial.SetActive(false);
        holoObj.SetActive(false);
        wristMenu.gameObject.SetActive(true);
    }

    public void CheckPlayer()
    {
        if(PlayerPrefs.GetInt("FirstTime") == 0)
        {
            triggerNPC.SetActive(false);
            chatTutorial.SetActive(true);
            holoObj.SetActive(true);
            wristMenu.gameObject.SetActive(false);

            #region Set No Data
            PlayerPrefs.SetString(saveAndLoadImageManager.key1a, "No Data");
            PlayerPrefs.SetString(saveAndLoadImageManager.key1b, "No Data");
            PlayerPrefs.SetString(saveAndLoadImageManager.key1c, "No Data");
            PlayerPrefs.SetString(saveAndLoadImageManager.key2a, "No Data");
            PlayerPrefs.SetString(saveAndLoadImageManager.key2b, "No Data");
            PlayerPrefs.SetString(saveAndLoadImageManager.key2c, "No Data");
            PlayerPrefs.SetString(saveAndLoadImageManager.key3a, "No Data");
            PlayerPrefs.SetString(saveAndLoadImageManager.key3b, "No Data");
            PlayerPrefs.SetString(saveAndLoadImageManager.key3c, "No Data");
            #endregion
        }
        else
        {
            placeTeleport.SetActive(true);
            wristMenu.gameObject.SetActive(true);
        }
    }    

    public void OnDelete()
    {
        PlayerPrefs.DeleteAll();
        checkPlayerInt = 0;
    }

    public void HandleButton(Button _button)
    {
        stepTutorials[6].SetActive(false);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].image.color = oldColor;
            if (_button == buttons[i])
            {               
                _button.image.color = newColor;
                if (_button == buttons[0])
                {
                    stepTutorials[0].SetActive(true);
                    stepTutorials[1].SetActive(false);
                    stepTutorials[2].SetActive(false);
                    stepTutorials[3].SetActive(false);
                    stepTutorials[4].SetActive(false);
                    stepTutorials[5].SetActive(false);
                    a = 1;
                    nextText.SetActive(true);
                    exitText.SetActive(false);
                }
                else if (_button == buttons[1])
                {
                    stepTutorials[1].SetActive(true);
                    stepTutorials[0].SetActive(false);
                    stepTutorials[2].SetActive(false);
                    stepTutorials[3].SetActive(false);
                    stepTutorials[4].SetActive(false);
                    stepTutorials[5].SetActive(false);
                    a = 2;
                    nextText.SetActive(true);
                    exitText.SetActive(false);
                }
                else if (_button == buttons[2])
                {
                    stepTutorials[2].SetActive(true);
                    stepTutorials[0].SetActive(false);
                    stepTutorials[1].SetActive(false);
                    stepTutorials[3].SetActive(false);
                    stepTutorials[4].SetActive(false);
                    stepTutorials[5].SetActive(false);
                    a = 3;
                    nextText.SetActive(true);
                    exitText.SetActive(false);
                }
                else if (_button == buttons[3])
                {
                    stepTutorials[3].SetActive(true);
                    stepTutorials[0].SetActive(false);
                    stepTutorials[1].SetActive(false);
                    stepTutorials[2].SetActive(false);
                    stepTutorials[4].SetActive(false);
                    stepTutorials[5].SetActive(false);
                    a = 4;
                    nextText.SetActive(true);
                    exitText.SetActive(false);
                }
                else if (_button == buttons[4])
                {
                    stepTutorials[4].SetActive(true);
                    stepTutorials[0].SetActive(false);
                    stepTutorials[1].SetActive(false);
                    stepTutorials[2].SetActive(false);
                    stepTutorials[3].SetActive(false);
                    stepTutorials[5].SetActive(false);
                    nextText.SetActive(true);
                    exitText.SetActive(false);
                    a = 5;
                }
                else if (_button == buttons[5])
                {
                    stepTutorials[5].SetActive(true);
                    stepTutorials[0].SetActive(false);
                    stepTutorials[1].SetActive(false);
                    stepTutorials[2].SetActive(false);
                    stepTutorials[3].SetActive(false);
                    stepTutorials[4].SetActive(false);
                    nextText.SetActive(false);
                    exitText.SetActive(true);
                    a = 6;
                }
            }            
        }
    }

    public void NextButton()
    {

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].image.color = oldColor;
        }

        if (a==0)
        {
            buttons[a].image.color = newColor;
            stepTutorials[0].SetActive(true);
            stepTutorials[1].SetActive(false);
            stepTutorials[2].SetActive(false);
            stepTutorials[3].SetActive(false);
            stepTutorials[4].SetActive(false);
            stepTutorials[5].SetActive(false);
            stepTutorials[6].SetActive(false);
            nextText.SetActive(true);
            exitText.SetActive(false);
            a = 1;
            
        }
        else if (a == 1)
        {
            buttons[a].image.color = newColor;
            stepTutorials[1].SetActive(true);
            stepTutorials[0].SetActive(false);
            stepTutorials[2].SetActive(false);
            stepTutorials[3].SetActive(false);
            stepTutorials[4].SetActive(false);
            stepTutorials[5].SetActive(false);
            stepTutorials[6].SetActive(false);
            nextText.SetActive(true);
            exitText.SetActive(false);
            a = 2;
        }
        else if (a == 2)
        {
            buttons[a].image.color = newColor;
            stepTutorials[2].SetActive(true);
            stepTutorials[0].SetActive(false);
            stepTutorials[1].SetActive(false);
            stepTutorials[3].SetActive(false);
            stepTutorials[4].SetActive(false);
            stepTutorials[5].SetActive(false);
            stepTutorials[6].SetActive(false);
            nextText.SetActive(true);
            exitText.SetActive(false);
            a = 3;
        }
        else if (a == 3)
        {
            buttons[a].image.color = newColor;
            stepTutorials[3].SetActive(true);
            stepTutorials[0].SetActive(false);
            stepTutorials[1].SetActive(false);
            stepTutorials[2].SetActive(false);
            stepTutorials[4].SetActive(false);
            stepTutorials[5].SetActive(false);
            stepTutorials[6].SetActive(false);
            nextText.SetActive(true);
            exitText.SetActive(false);
            a = 4;
        }
        else if (a == 4)
        {
            buttons[a].image.color = newColor;
            stepTutorials[4].SetActive(true);
            stepTutorials[0].SetActive(false);
            stepTutorials[1].SetActive(false);
            stepTutorials[2].SetActive(false);
            stepTutorials[3].SetActive(false);
            stepTutorials[5].SetActive(false);
            stepTutorials[6].SetActive(false);
            nextText.SetActive(true);
            exitText.SetActive(false);
            a = 5;
        }
        else if (a == 5)
        {
            buttons[a].image.color = newColor;
            stepTutorials[5].SetActive(true);
            stepTutorials[0].SetActive(false);
            stepTutorials[1].SetActive(false);
            stepTutorials[2].SetActive(false);
            stepTutorials[3].SetActive(false);
            stepTutorials[4].SetActive(false);
            stepTutorials[6].SetActive(false);
            nextText.SetActive(true);
            exitText.SetActive(false);
            a = 6;
        }
        else if(a==6)
        {
            stepTutorials[6].SetActive(true);
            stepTutorials[0].SetActive(false);
            stepTutorials[1].SetActive(false);
            stepTutorials[2].SetActive(false);
            stepTutorials[3].SetActive(false);
            stepTutorials[4].SetActive(false);
            stepTutorials[5].SetActive(false);
            nextText.SetActive(false);
            exitText.SetActive(true);
            a = 7;
        }
        else if (a == 7)
        {

            OnClickSave();
        }
    }

   
}
