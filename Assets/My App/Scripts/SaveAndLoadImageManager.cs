using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using OpenAI;
using UnityEngine.UI;
using TMPro;

public class SaveAndLoadImageManager : MonoBehaviour
{
    PlaceDetector placeDetector;
    DallE dallE;
    ChatGPT2 chatGPT2;
    CheckSlotSaveAndLoad checkSlotSaveAndLoad;

    public TMP_Text _miniMenuText;
    public GameObject defaultFeature;
    public GameObject saveFeature;
    public GameObject loadFeature;
    public Button[] saveSlot;
    public Button[] loadSlot;
    public Image[] imageSaveSlot;
    public Image[] imageLoadSlot;
    public TMP_Text[] textSaveSlot;
    public TMP_Text[] textLoadSlot;
    public Image secondLoad;

    [Header ("Key Text")]
    public string key1a = "text1a_key";
    public string key1b = "text1b_key";
    public string key1c = "text1c_key";
    public string key2a = "text2a_key";
    public string key2b = "text2b_key";
    public string key2c = "text2c_key";
    public string key3a = "text3a_key";
    public string key3b = "text3b_key";
    public string key3c = "text3c_key";

    private void Start()
    {
        placeDetector = FindObjectOfType<PlaceDetector>();
        dallE = FindObjectOfType<DallE>();
        chatGPT2 = FindObjectOfType<ChatGPT2>();
        checkSlotSaveAndLoad = FindObjectOfType<CheckSlotSaveAndLoad>();


    }

    private void Update()
    {

    }

    public void SaveSlot()
    {
        if (dallE.checkMiniButton == true)
        {
            CheckForButtonSave();
        }
    }    

    public void LoadSlot()
    {
        if (dallE.checkMiniButton == true)
        {
            CheckForButtonLoad();

        }
    }    

    public void SaveImage(Image image, string fireName)
    {
        Debug.Log(Application.persistentDataPath);
        Texture2D texture = new Texture2D(image.sprite.texture.width, image.sprite.texture.height, TextureFormat.RGBA32, false);
        texture.SetPixels(image.sprite.texture.GetPixels());
        texture.Apply();
        File.WriteAllBytes(Application.persistentDataPath + "/" + fireName +".png", texture.EncodeToPNG());
        Debug.Log("Save");
    }

    public void LoadImage(Image loadImage, string fireName)
    {
        string filePath = Application.persistentDataPath + "/" + fireName + ".png";

        if (File.Exists(filePath))
        {
            byte[] bytes = File.ReadAllBytes(filePath);
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(bytes);
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1f);
            loadImage.sprite = sprite;

        }
        else
        {
            Debug.Log("No file to load");
            loadImage.sprite = secondLoad.sprite;
        }
    }

    public void OnClickSave()
    {
        if(placeDetector.namePlaces.text == "Museum 1" || placeDetector.namePlaces.text == "Museum 2" || placeDetector.namePlaces.text == "Museum 3")
        {
            saveFeature.SetActive(true);
            defaultFeature.SetActive(false);
            if (placeDetector.namePlaces.text == "Museum 1")
            {
                LoadImage(imageSaveSlot[0], "imageM1a");
                LoadImage(imageSaveSlot[1], "imageM1b");
                LoadImage(imageSaveSlot[2], "imageM1c"); 
                textSaveSlot[0].text = PlayerPrefs.GetString(key1a);
                textSaveSlot[1].text = PlayerPrefs.GetString(key1b);
                textSaveSlot[2].text = PlayerPrefs.GetString(key1c);
            }
            else if (placeDetector.namePlaces.text == "Museum 2")
            {
                LoadImage(imageSaveSlot[0], "imageM2a");
                LoadImage(imageSaveSlot[1], "imageM2b");
                LoadImage(imageSaveSlot[2], "imageM2c");
                textSaveSlot[0].text = PlayerPrefs.GetString(key2a);
                textSaveSlot[1].text = PlayerPrefs.GetString(key2b);
                textSaveSlot[2].text = PlayerPrefs.GetString(key2c);
            }
            else if (placeDetector.namePlaces.text == "Museum 3")
            {
                LoadImage(imageSaveSlot[0], "imageM3a");
                LoadImage(imageSaveSlot[1], "imageM3b");
                LoadImage(imageSaveSlot[2], "imageM3c");
                textSaveSlot[0].text = PlayerPrefs.GetString(key3a);
                textSaveSlot[1].text = PlayerPrefs.GetString(key3b);
                textSaveSlot[2].text = PlayerPrefs.GetString(key3c);
            }
        }   
        else
        {
            _miniMenuText.text = "Dear visitor, to save or load image, please go to the museum";
        }    
    }

    public void OnClickLoad()
    {
        if (placeDetector.namePlaces.text == "Museum 1" || placeDetector.namePlaces.text == "Museum 2" || placeDetector.namePlaces.text == "Museum 3")
        {
            loadFeature.SetActive(true);
            defaultFeature.SetActive(false);
            if(placeDetector.namePlaces.text == "Museum 1")
            {
                LoadImage(imageLoadSlot[0], "imageM1a");
                LoadImage(imageLoadSlot[1], "imageM1b");
                LoadImage(imageLoadSlot[2], "imageM1c");
                textLoadSlot[0].text = PlayerPrefs.GetString(key1a);
                textLoadSlot[1].text = PlayerPrefs.GetString(key1b);
                textLoadSlot[2].text = PlayerPrefs.GetString(key1c);
            }    
            else if(placeDetector.namePlaces.text == "Museum 2")
            {
                LoadImage(imageLoadSlot[0], "imageM2a");
                LoadImage(imageLoadSlot[1], "imageM2b");
                LoadImage(imageLoadSlot[2], "imageM2c");
                textLoadSlot[0].text = PlayerPrefs.GetString(key2a);
                textLoadSlot[1].text = PlayerPrefs.GetString(key2b);
                textLoadSlot[2].text = PlayerPrefs.GetString(key2c);
            }
            else if (placeDetector.namePlaces.text == "Museum 3")
            {
                LoadImage(imageLoadSlot[0], "imageM3a");
                LoadImage(imageLoadSlot[1], "imageM3b");
                LoadImage(imageLoadSlot[2], "imageM3c");
                textLoadSlot[0].text = PlayerPrefs.GetString(key3a);
                textLoadSlot[1].text = PlayerPrefs.GetString(key3b);
                textLoadSlot[2].text = PlayerPrefs.GetString(key3c);
            }

        }
        else
        {
            _miniMenuText.text = "Dear visitor, to save or load image, please go to the museum";
        }
    }

    public void CheckForButtonSave()
    {
        if (placeDetector.namePlaces.text == "Museum 1")
        {
            if (dallE.checkGeneM1 == true)
            {
                if (checkSlotSaveAndLoad.saveSlot1 == true)
                {
                    SaveImage(dallE.imageM1, "imageM1a");
                    string value1 = chatGPT2.textAreaM1.text;
                    PlayerPrefs.SetString(key1a, value1);
                    imageSaveSlot[0].sprite = dallE.imageM1.sprite;
                    textSaveSlot[0].text = value1;
                    dallE.checkGeneM1 = false;
                }
                else if (checkSlotSaveAndLoad.saveSlot2 == true)
                {
                    SaveImage(dallE.imageM1, "imageM1b");
                    string value1 = chatGPT2.textAreaM1.text;
                    PlayerPrefs.SetString(key1b, value1);
                    imageSaveSlot[1].sprite = dallE.imageM1.sprite;
                    textSaveSlot[1].text = value1;
                    dallE.checkGeneM1 = false;
                }
                else if (checkSlotSaveAndLoad.saveSlot3 == true)
                {
                    SaveImage(dallE.imageM1, "imageM1c");
                    string value1 = chatGPT2.textAreaM1.text;
                    PlayerPrefs.SetString(key1c, value1);
                    imageSaveSlot[2].sprite = dallE.imageM1.sprite;
                    textSaveSlot[2].text = value1;
                    dallE.checkGeneM1 = false;
                }
            }
            else
            {
                Debug.Log("Nothing, Can't Save");
                _miniMenuText.text = "Dear visitor, in order to save the picture, you need to generate it first.";
            }
        }
        else if (placeDetector.namePlaces.text == "Museum 2")
        {
            if (dallE.checkGeneM2 == true)
            {
                if (checkSlotSaveAndLoad.saveSlot1 == true)
                {

                    SaveImage(dallE.imageM2, "imageM2a");
                    string value1 = chatGPT2.textAreaM2.text;
                    PlayerPrefs.SetString(key2a, value1);
                    imageSaveSlot[0].sprite = dallE.imageM2.sprite;
                    textSaveSlot[0].text = value1;
                    dallE.checkGeneM2 = false;
                }
                else if (checkSlotSaveAndLoad.saveSlot2 == true)
                {
                    SaveImage(dallE.imageM2, "imageM2b");
                    string value1 = chatGPT2.textAreaM2.text;
                    PlayerPrefs.SetString(key2b, value1);
                    imageSaveSlot[1].sprite = dallE.imageM2.sprite;
                    textSaveSlot[1].text = value1;
                    dallE.checkGeneM2 = false;
                }
                else if (checkSlotSaveAndLoad.saveSlot3 == true)
                {
                    SaveImage(dallE.imageM2, "imageM2c");
                    string value1 = chatGPT2.textAreaM2.text;
                    PlayerPrefs.SetString(key2c, value1);
                    imageSaveSlot[2].sprite = dallE.imageM2.sprite;
                    textSaveSlot[2].text = value1;
                    dallE.checkGeneM2 = false;
                }
            }
            else
            {
                Debug.Log("Nothing, Can't Save");
                _miniMenuText.text = "Dear visitor, in order to save the picture, you need to generate it first.";
            }
        }
        else if (placeDetector.namePlaces.text == "Museum 3")
        {
            if (dallE.checkGeneM3 == true)
            {
                if (checkSlotSaveAndLoad.saveSlot1 == true)
                {
                    SaveImage(dallE.imageM3, "imageM3a");
                    string value1 = chatGPT2.textAreaM3.text;
                    PlayerPrefs.SetString(key3a, value1);
                    imageSaveSlot[0].sprite = dallE.imageM3.sprite;
                    textSaveSlot[0].text = value1;
                    dallE.checkGeneM3 = false;
                }
                else if (checkSlotSaveAndLoad.saveSlot2 == true)
                {
                    SaveImage(dallE.imageM3, "imageM3b");
                    string value1 = chatGPT2.textAreaM3.text;
                    PlayerPrefs.SetString(key3b, value1);
                    imageSaveSlot[1].sprite = dallE.imageM3.sprite;
                    textSaveSlot[1].text = value1;
                    dallE.checkGeneM3 = false;
                }
                else if (checkSlotSaveAndLoad.saveSlot3 == true)
                {
                    SaveImage(dallE.imageM3, "imageM3c");
                    string value1 = chatGPT2.textAreaM3.text;
                    PlayerPrefs.SetString(key3c, value1);
                    imageSaveSlot[2].sprite = dallE.imageM3.sprite;
                    textSaveSlot[2].text = value1;
                    dallE.checkGeneM3 = false;
                }
            }
            else
            {
                Debug.Log("Nothing, Can't Save");
                _miniMenuText.text = "Dear visitor, in order to save the picture, you need to generate it first.";
            }
        }
        else
        {
            saveFeature.SetActive(false);
            defaultFeature.SetActive(true);
            _miniMenuText.text = "Dear visitor, to save or load image, please go to the museum";
        }
    }

    public void CheckForButtonLoad()
    {
        if (placeDetector.namePlaces.text == "Museum 1")
        {
            if(checkSlotSaveAndLoad.saveSlot1 == true)
            {
                LoadImage(dallE.imageM1, "imageM1a");
                string value1 = PlayerPrefs.GetString(key1a);
                chatGPT2.textAreaM1.text = value1;
            }
            else if (checkSlotSaveAndLoad.saveSlot2 == true)
            {
                LoadImage(dallE.imageM1, "imageM1b");
                string value1 = PlayerPrefs.GetString(key1b);
                chatGPT2.textAreaM1.text = value1;
            }
            else if (checkSlotSaveAndLoad.saveSlot3 == true)
            {
                LoadImage(dallE.imageM1, "imageM1c");
                string value1 = PlayerPrefs.GetString(key1c);
                chatGPT2.textAreaM1.text = value1;
            }
        }
        else if (placeDetector.namePlaces.text == "Museum 2")
        {
            if (checkSlotSaveAndLoad.saveSlot1 == true)
            {
                LoadImage(dallE.imageM2, "imageM2a");
                string value1 = PlayerPrefs.GetString(key2a);
                chatGPT2.textAreaM2.text = value1;
            }
            else if (checkSlotSaveAndLoad.saveSlot2 == true)
            {
                LoadImage(dallE.imageM2, "imageM2b");
                string value1 = PlayerPrefs.GetString(key2b);
                chatGPT2.textAreaM2.text = value1;
            }
            else if (checkSlotSaveAndLoad.saveSlot3 == true)
            {
                LoadImage(dallE.imageM2, "imageM2c");
                string value1 = PlayerPrefs.GetString(key2c);
                chatGPT2.textAreaM2.text = value1;
            }
        }
        else if (placeDetector.namePlaces.text == "Museum 3")
        {
            if (checkSlotSaveAndLoad.saveSlot1 == true)
            {
                LoadImage(dallE.imageM3, "imageM3a");
                string value1 = PlayerPrefs.GetString(key3a);
                chatGPT2.textAreaM3.text = value1;
            }
            else if (checkSlotSaveAndLoad.saveSlot2 == true)
            {
                LoadImage(dallE.imageM3, "imageM3b");
                string value1 = PlayerPrefs.GetString(key3b);
                chatGPT2.textAreaM3.text = value1;
            }
            else if (checkSlotSaveAndLoad.saveSlot3 == true)
            {
                LoadImage(dallE.imageM3, "imageM3c");
                string value1 = PlayerPrefs.GetString(key3c);
                chatGPT2.textAreaM3.text = value1;
            }
        }
        else
        {
            loadFeature.SetActive(false);
            defaultFeature.SetActive(true);
            _miniMenuText.text = "Dear visitor, to save or load image, please go to the museum";
        }
    }
}
