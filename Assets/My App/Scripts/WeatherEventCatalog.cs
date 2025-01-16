using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeatherEventCatalog : MonoBehaviour
{
    public TMP_Text textSelect;
    public Image contentImage;
    public GameObject[] objControl;

    public void OnCLickWeather(string _buttonText)
    {
        textSelect.text = _buttonText;
    }

    public void ChangeSprite(Button _button)
    {
         contentImage.sprite = _button.image.sprite;
    }

    public void AnimationClick(GameObject obj)
    {
        for(int i = 0; i < objControl.Length; i++)
        {
            objControl[i].SetActive(false);
        }

        obj.SetActive(true);
        Animator ani;
        ani = obj.GetComponent<Animator>();
        ani.Play("On");
    }
}
