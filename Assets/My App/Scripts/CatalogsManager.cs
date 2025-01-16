using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CatalogsManager : MonoBehaviour
{
    [Header("FullShow")]
    #region Text
    public TMP_Text timeOfDayText;
    public TMP_Text areaText;
    public TMP_Text emoText;
    public TMP_Text socialText;
    public TMP_Text placeText;
    public TMP_Text weatherText;
    public TMP_Text seasonText;
    public TMP_Text promptText;
    #endregion

    #region sprites
    public Image timeOfDayImage;
    public Image emoImage;
    public Image placeImage;
    public Image seasonImage;
    #endregion

    [Header("TOD")]
    public TMP_Text todSelectText;
    public bool haveSelectTOD = false;

    [Header("Area")]
    public TMP_Text areaSelectText;

    [Header("Emotion")]
    public TMP_Text emoSelectText;

    [Header("Social")]
    public TMP_Text socialSelectText;

    [Header("Place")]
    public TMP_Text placeSelectText;

    [Header("Weather")]
    public TMP_Text weatherSelectText;

    [Header("Season")]
    public TMP_Text seasonSelectText;

    [Header("Prompt")]
    public TMP_InputField promptInput;

    public TMP_InputField dallEInput;
    public TMP_InputField chatGPTInput;


    private void Update()
    {
        YourPrompt();
        YourPromptChatGPT();
    }

    public void TODClick(Image todSprite)
    {
        timeOfDayText.text = todSelectText.text;
        timeOfDayImage.sprite = todSprite.sprite;
        haveSelectTOD = true;
    }

    public void SkipTOD(Image todSprite)
    {
        if(haveSelectTOD == false)
        {
            timeOfDayText.text = todSelectText.text;
            timeOfDayImage.sprite = todSprite.sprite;
        }
    }

    public void AreaCick()
    {
        areaText.text = areaSelectText.text;
    }

    public void EmoClick()
    {
        emoText.text = emoSelectText.text;
    }

    public void SocialClick()
    {
        socialText.text = socialSelectText.text;
    }

    public void PlaceClick()
    {
        placeText.text = placeSelectText.text;
    }

    public void WeatherClick()
    {
        weatherText.text = weatherSelectText.text;
    }

    public void SeasonClick()
    {
        seasonText.text = seasonSelectText.text;
    }
    public void PromptClick()
    {
        promptText.text = promptInput.text;
    }

    public void YourPrompt()
    {
        dallEInput.text = "In " + timeOfDayText.text + " ,Area " + areaText.text + " ,Feeling " + emoSelectText.text + " ,Go " + socialText.text
            + ",Place " + placeText.text + ",Weather is " + weatherText.text + " ,Season is " + seasonText.text + " and " + promptText.text + " with style photography, 4k, highly detailed. editorial image.";
    }
    public void YourPromptChatGPT()
    {
        chatGPTInput.text = "Write for me a prompt use in DallE with 1 line about: " + "In " + timeOfDayText.text + " ,Area " + areaText.text + " ,Feeling " + emoSelectText.text + " ,Go " + socialText.text
            + ",Place " + placeText.text + ",Weather is " + weatherText.text + " ,Season is " + seasonText.text + " and " + promptText.text ;
    }
}
