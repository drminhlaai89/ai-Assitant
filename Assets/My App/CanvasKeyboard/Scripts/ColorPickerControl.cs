using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorPickerControl : MonoBehaviour
{
    public float currentHue, currentSat, currentVal;
    [SerializeField] private RawImage hueImage, satValImage, outputImage, outputImage2;
    [SerializeField] private Slider hueslider;
    [SerializeField] private TMP_Text hexText;
    [SerializeField] private TMP_InputField inputHexText;

    private Texture2D hueTexture, svTexture, outputTexture;

    private void Start()
    {
        CreatHueImage();
        CreatSVImage();
        CreatOutputImage();
        UpdateOutPutImage();
    }

    private void CreatHueImage()
    {
        hueTexture = new Texture2D(1, 16);
        hueTexture.wrapMode = TextureWrapMode.Clamp;
        hueTexture.name = "HueTexture";
        for(int i = 0; i<hueTexture.height; i++)
        {
            hueTexture.SetPixel(0, i, Color.HSVToRGB((float)i / hueTexture.height, 1, 1));
        }
        hueTexture.Apply();
        currentHue = 0;
        hueImage.texture = hueTexture;
    }
    private void CreatSVImage()
    {
        svTexture = new Texture2D(16, 16);
        svTexture.wrapMode = TextureWrapMode.Clamp;
        svTexture.name = "SatValTexture";

        for (int y = 0; y < svTexture.height; y++)
        {
            for (int x = 0; x < svTexture.height; x++)
            {
                svTexture.SetPixel(x, y, Color.HSVToRGB(currentHue, (float)x / svTexture.width, (float)y / svTexture.height));
            }
        }

        svTexture.Apply();
        currentSat = 0;
        currentVal = 0;
        satValImage.texture = svTexture;
    }
    private void CreatOutputImage()
    {
        outputTexture = new Texture2D(1, 16);
        outputTexture.wrapMode = TextureWrapMode.Clamp;
        outputTexture.name = "OutPutTexture";

        Color currentColor = Color.HSVToRGB(currentHue, currentSat, currentVal);

        for (int i = 0; i < outputTexture.height; i++)
        {
            outputTexture.SetPixel(0, i, currentColor);
        }

        outputTexture.Apply();
        outputImage.texture = outputTexture;
        outputImage2.texture = outputTexture;
    }
    private void UpdateOutPutImage()
    {
        Color currentColor = Color.HSVToRGB(currentHue, currentSat, currentVal);

        for (int i = 0; i < outputTexture.height; i++)
        {
            outputTexture.SetPixel(0, i, currentColor);
        }

        outputTexture.Apply();
        inputHexText.text = ColorUtility.ToHtmlStringRGB(currentColor);
    }   
    public void SetSV(float S, float V)
    {
        currentSat = S;
        currentVal = V;

        UpdateOutPutImage();
    }
    public void UpdateSVColor()
    {
        currentHue = hueslider.value;
        for (int y = 0; y < svTexture.height; y++)
        {
            for (int x = 0; x < svTexture.width; x++)
            {
                svTexture.SetPixel(x, y, Color.HSVToRGB(currentHue, (float)x / svTexture.width, (float)y / svTexture.height));
            }
        }
        Debug.Log(currentVal);
        Debug.Log(currentSat);
        Debug.Log("Hue "+currentHue);
        svTexture.Apply();
        UpdateOutPutImage();
    }

    public void OnTextInput()
    {
        if(inputHexText.text.Length < 6)
        {
            return;
        }

        Color newCol;

        if(ColorUtility.TryParseHtmlString("#" + inputHexText.text, out newCol))
            Color.RGBToHSV(newCol, out currentHue, out currentSat, out currentVal);

        hueslider.value = currentHue;
        inputHexText.text = "";
        UpdateOutPutImage();
    }    
}
