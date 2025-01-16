using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmoMenuControl : MonoBehaviour
{
    public XRSlider slider;
    
    public Animator[] emoAni;
    public GameObject[] miniEmo;
    public Image panelOutput;
    public TMP_Text emoSelectText;

    public Color32 color1;
    public Color32 color2;
    public Color32 color3;
    public Color32 color4;
    public Color32 color5;

    CatalogsManager catalogsManager;

    private void Awake()
    {
        catalogsManager = FindObjectOfType<CatalogsManager>();
    }
    private void FixedUpdate()
    {
        CheckSlider();
    }

    public void CheckSlider()
    {
        float sliderValue = slider.value;
        for (int i = 0; i < emoAni.Length; i++)
        {
            emoAni[i].SetFloat("On", sliderValue);
        }

        for (int j = 0; j < miniEmo.Length; j++)
        {
            miniEmo[j].SetActive(false);
            if (sliderValue < 1)
            {
                panelOutput.color = color1;
                miniEmo[0].SetActive(true);
                emoSelectText.text = "Love";
                catalogsManager.emoImage.sprite = miniEmo[0].GetComponent<Image>().sprite;
            }
            else if (sliderValue >= 1 && sliderValue < 2)
            {
                panelOutput.color = color2;
                miniEmo[1].SetActive(true);
                emoSelectText.text = "Happy";
                catalogsManager.emoImage.sprite = miniEmo[1].GetComponent<Image>().sprite;
            }
            else if (sliderValue >= 2 && sliderValue < 3)
            {
                panelOutput.color = color3;
                miniEmo[2].SetActive(true);
                emoSelectText.text = "Neutral";
                catalogsManager.emoImage.sprite = miniEmo[2].GetComponent<Image>().sprite;
            }
            else if (sliderValue >= 3 && sliderValue < 4)
            {
                panelOutput.color = color4;
                miniEmo[3].SetActive(true);
                emoSelectText.text = "Sad";
                catalogsManager.emoImage.sprite = miniEmo[3].GetComponent<Image>().sprite;
            }
            else if (sliderValue >= 4 && sliderValue <= 5)
            {
                panelOutput.color = color5;
                miniEmo[4].SetActive(true);
                emoSelectText.text = "Angry";
                catalogsManager.emoImage.sprite = miniEmo[4].GetComponent<Image>().sprite;
            }
        }
    }

    public void RandomSlider()
    {
        int randomSlider = Random.Range(0, 7);
        slider.value = randomSlider;
    }
}
