using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
using UnityEditor;
using TalesFromTheRift;


namespace MQ
{
    public class MenuManager : MonoBehaviour
    {
        [Header("Choose Option")]
        [SerializeField] private GameObject chooseColorButton;
        [SerializeField] private GameObject chooseEmoButton;
        [SerializeField] private GameObject selectPromptButton;
        [SerializeField] private GameObject saveButton;
        [SerializeField] private GameObject controlMenu;
        [SerializeField] private GameObject locationButton;

        [Header("Pick Color Text")]
        [SerializeField] private GameObject pickColor;
        [SerializeField] private TMP_Text colorSelectText;
        [SerializeField] private TMP_InputField colorPickerText;
        [SerializeField] private bool hsColor; //have select

        [Header("ColorPack")]
        [SerializeField] private GameObject colorPack;
        [SerializeField] private GameObject[] colorButtons;

        [Header("Pick Emo Text")]
        [SerializeField] private GameObject pickEmo;
        [SerializeField] private TMP_Text emoSelectText;
        [SerializeField] private bool hsEmo;

        [Header("EmoPack")]
        [SerializeField] private GameObject emoPack;
        [SerializeField] private GameObject[] emoButtons;
        [SerializeField] private GameObject[] miniEmo;

        [Header("Pick Sky Text")]
        [SerializeField] private GameObject pickSky;
        [SerializeField] private TMP_Text skySelectText;
        [SerializeField] private bool hsSky;

        [Header("SkyPack")]
        [SerializeField] private GameObject skyPack;
        [SerializeField] private GameObject[] skyButtons;

        [Header("Pick Prompt Text")]
        [SerializeField] private GameObject pickPrompt;
        [SerializeField] private TMP_InputField promptText;
        [SerializeField] private TMP_InputField promptGPTText;
        [SerializeField] private TMP_InputField bonuspromptText;

        [Header("Gene Picture")]
        [SerializeField] private GameObject imgGene;
        [SerializeField] private Image image;

        [Header("Voice")]
        [SerializeField] private GameObject buttonActiveVoice;
        [SerializeField] private GameObject textActive;
        [SerializeField] private TMP_Text audioText;
        [SerializeField] private GameObject textDeactive;
        [SerializeField] private bool bActive;


        [Header("Full Show")]
        [SerializeField] private TMP_Text promptTextFullShow;
        //public CanvasKeyboard canvasKeyboard;

        //[SerializeField] private Texture newtex;

        public void Update()
        {
            /*if (hsColor && hsEmo && hsSky)
            {
                selectPromptButton.SetActive(true);
            }*/
            YourPrompt();
            YourPromptChatGPT();
            //colorSelectText.text = colorPickerText.text;
            /* myTexture = new Texture2D(2, 2);
            byte[] data = File.ReadAllBytes(Application.dataPath + "/../Assets/TexturebyGene/myTexture.png");
            myTexture.LoadImage(data);*/
        }

        #region On Click Button
        public void OnClickSelectSave()
        {
            SaveTexture();
            Debug.Log("Save");
            //AssetDatabase.Refresh();
            //imgGene.SetActive(false);
        }

        public void OnClickSkyBoxMaker()
        {
            SkyboxChanger();
            Debug.Log("SkyBox Make");
        }

        /*public void OnClickChooseColor()
        {
            colorPack.SetActive(true);
            hsColor = true;
        }

        public void OnClickChooseEmo()
        {
            emoPack.SetActive(true);
            hsEmo = true;
        }
        public void OnClickChoosSky()
        {
            skyPack.SetActive(true);
            hsSky = true;
            
        }*/

        public void OnClickPickColor(string text)
        {
            //pickColor.SetActive(true);
            //colorSelectText.text = string.Join(",", colorButtons(colorSelectText => colorSelectText.name).ToArray());
            colorSelectText.text = text;
            //colorPack.SetActive(false);
        }

        public void OnClickPickEmo(string text)
        {
            //pickEmo.SetActive(true);
            emoSelectText.text = text;
            //emoPack.SetActive(false);

            switch(text)
            {
                case "Neutral":
                    miniEmo[0].SetActive(true);
                    for(int i = 1; i < miniEmo.Length; i++)
                    {
                        miniEmo[i].SetActive(false);
                    }    
                    break;

                case "Love":
                    miniEmo[1].SetActive(true);
                    miniEmo[0].SetActive(false);
                    for (int i = 2; i < miniEmo.Length; i++)
                    {
                        miniEmo[i].SetActive(false);
                    }
                    break;
                case "Happy":
                    miniEmo[2].SetActive(true);
                    miniEmo[0].SetActive(false);
                    miniEmo[1].SetActive(false);
                    for (int i = 3; i < miniEmo.Length; i++)
                    {
                        miniEmo[i].SetActive(false);
                    }
                    break;
                case "Wow":
                    miniEmo[3].SetActive(true);
                    miniEmo[0].SetActive(false);
                    miniEmo[1].SetActive(false);
                    miniEmo[2].SetActive(false);
                    for (int i = 4; i < miniEmo.Length; i++)
                    {
                        miniEmo[i].SetActive(false);
                    }
                    break;
                case "Sad":
                    miniEmo[4].SetActive(true);
                    miniEmo[5].SetActive(false);
                    for (int i = 0; i < 4; i++)
                    {
                        miniEmo[i].SetActive(false);
                    }
                    break;
                case "Angry":
                    miniEmo[5].SetActive(true);
                    for (int i = 0; i < 5; i++)
                    {
                        miniEmo[i].SetActive(false);
                    }
                    break;
            }    

        }

        public void OnClickPickSky(string text)
        {
            //pickSky.SetActive(true);
            skySelectText.text = text;
            //skyPack.SetActive(false);
        }

        public void OnClickPickPrompt()
        {
            promptTextFullShow.text = bonuspromptText.text;
        }    

        public void YourPrompt()
        {
            promptText.text = "Color "+ colorSelectText.text + "' , Feeling " + emoSelectText.text 
                + ", Sky state " + skySelectText.text + " and "+ bonuspromptText.text ;
        }
        public void YourPromptChatGPT()
        {
            promptGPTText.text = "Give me a sentence in 1 line about: ,Color "+ colorSelectText.text + " Feeling " + emoSelectText.text + ", Sky state "
                + skySelectText.text + " and " + bonuspromptText.text ;
        }

        public void OnClickCreatPrompt()
        {
            //imgGene.SetActive(true);
            saveButton.SetActive(false);
            controlMenu.SetActive(false);
            
        }
        public void SaveTexture()
        {
            Texture2D texture = new Texture2D(image.sprite.texture.width, image.sprite.texture.height, TextureFormat.RGBA32, false);
            texture.SetPixels(image.sprite.texture.GetPixels());
            texture.Apply();
            File.WriteAllBytes(Application.dataPath + "/TexturebyGene/myTexture.png", texture.EncodeToPNG());
        }
        
        public void SkyboxChanger()
        {
            string assetPath = "Assets/TexturebyGene/myTexture.png";
            //TextureImporter importer = (TextureImporter)AssetImporter.GetAtPath(assetPath);
            //importer.textureShape = TextureImporterShape.TextureCube;
            //AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceUpdate);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(File.ReadAllBytes(assetPath));
            Material skyboxMaterial = new Material(Shader.Find("Skybox/Panoramic"));
            skyboxMaterial.SetTexture("_MainTex", texture);
            RenderSettings.skybox = skyboxMaterial;
        }

        public void OnClickActive()
        {
            
            if(bActive)
            {
                bActive = false;
               
            }
            else
            {
                bActive = true;
               
            }
        }
        #endregion
    }
}
