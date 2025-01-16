using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Threading.Tasks;

namespace OpenAI
{
    public class DallE : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private Button button;
        [SerializeField] private GameObject saveButton;
        [SerializeField] private GameObject loadButton;

        [Header("Museum 1")]
        public Image imageM1;
        [SerializeField] private GameObject loadingLabelM1;
        public bool checkGeneM1 = false;

        [Header("Museum 2")]
        public Image imageM2;
        [SerializeField] private GameObject loadingLabelM2;
        public bool checkGeneM2 = false;

        [Header("Museum 3")]
        public Image imageM3;
        [SerializeField] private GameObject loadingLabelM3;
        public bool checkGeneM3 = false;

        public bool checkMiniButton = true;

        PlaceDetector placeDetector;
        SaveAndLoadImageManager saveAndLoadImageManager;

        private OpenAIApi openai = new OpenAIApi("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");

        private void Start()
        {
            placeDetector = FindObjectOfType<PlaceDetector>();
            saveAndLoadImageManager = FindObjectOfType<SaveAndLoadImageManager>();
            button.onClick.AddListener(SendImageRequest);

        }

        private async void SendImageRequest()
        {        
            button.enabled = false;
            inputField.enabled = false;
            checkMiniButton = false;


            if (placeDetector.namePlaces.text == "Museum 1")
            {
                imageM1.sprite = null;
                loadingLabelM1.SetActive(true);

                var response = await openai.CreateImage(new CreateImageRequest
                {
                    Prompt = inputField.text,
                    Size = ImageSize.Size256
                });

                if (response.Data != null && response.Data.Count > 0)
                {
                    using (var request = new UnityWebRequest(response.Data[0].Url))
                    {
                        request.downloadHandler = new DownloadHandlerBuffer();
                        request.SetRequestHeader("Access-Control-Allow-Origin", "*");
                        request.SendWebRequest();

                        while (!request.isDone) await Task.Yield();

                        Texture2D texture = new Texture2D(2, 2);
                        texture.LoadImage(request.downloadHandler.data);
                        var sprite = Sprite.Create(texture, new Rect(0, 0, 256, 256), Vector2.zero, 1f);
                        imageM1.sprite = sprite;
                        Debug.Log("Gene complete");

                        
                        
                        //saveButton.SetActive(true);
                        //loadButton.SetActive(true);
                        checkGeneM1 = true;
                    }
                }
                else
                {
                    Debug.LogWarning("No image was created from this prompt.");
                }
            }
            else if (placeDetector.namePlaces.text == "Museum 2")
            {
                imageM2.sprite = null;
                loadingLabelM2.SetActive(true);

                var response = await openai.CreateImage(new CreateImageRequest
                {
                    Prompt = inputField.text,
                    Size = ImageSize.Size256
                });

                if (response.Data != null && response.Data.Count > 0)
                {
                    using (var request = new UnityWebRequest(response.Data[0].Url))
                    {
                        request.downloadHandler = new DownloadHandlerBuffer();
                        request.SetRequestHeader("Access-Control-Allow-Origin", "*");
                        request.SendWebRequest();

                        while (!request.isDone) await Task.Yield();

                        Texture2D texture = new Texture2D(2, 2);
                        texture.LoadImage(request.downloadHandler.data);
                        var sprite = Sprite.Create(texture, new Rect(0, 0, 256, 256), Vector2.zero, 1f);
                        imageM2.sprite = sprite;
                        Debug.Log("Gene complete");

                        saveButton.SetActive(true);
                        loadButton.SetActive(true);
                        checkGeneM2 = true;
                    }
                }
                else
                {
                    Debug.LogWarning("No image was created from this prompt.");
                }
            }
            else if (placeDetector.namePlaces.text == "Museum 3")
            {
                imageM3.sprite = null;
                loadingLabelM3.SetActive(true);

                var response = await openai.CreateImage(new CreateImageRequest
                {
                    Prompt = inputField.text,
                    Size = ImageSize.Size256
                });

                if (response.Data != null && response.Data.Count > 0)
                {
                    using (var request = new UnityWebRequest(response.Data[0].Url))
                    {
                        request.downloadHandler = new DownloadHandlerBuffer();
                        request.SetRequestHeader("Access-Control-Allow-Origin", "*");
                        request.SendWebRequest();

                        while (!request.isDone) await Task.Yield();

                        Texture2D texture = new Texture2D(2, 2);
                        texture.LoadImage(request.downloadHandler.data);
                        var sprite = Sprite.Create(texture, new Rect(0, 0, 256, 256), Vector2.zero, 1f);
                        imageM3.sprite = sprite;
                        Debug.Log("Gene complete");

                        saveButton.SetActive(true);
                        loadButton.SetActive(true);
                        checkGeneM3 = true;
                    }
                }
                else
                {
                    Debug.LogWarning("No image was created from this prompt.");
                }
            }
            else
            {
                Debug.Log("No image in this room");
            }


            checkMiniButton = true;
            button.enabled = true;
            inputField.enabled = true;
            loadingLabelM1.SetActive(false);
            loadingLabelM2.SetActive(false);
            loadingLabelM3.SetActive(false);
        }
    }
}
