using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Threading.Tasks;

namespace OpenAI
{
    public class DallE1 : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private Button button;
        [SerializeField] private GameObject saveButton;
        [SerializeField] private GameObject loadButton;

        public Image iconImage;
        public Image image;
        public Image imageBig;
        public GameObject loadingLabel;

        public GameObject iconHello;
        public GameObject iconPoint;
        public GameObject iconThink;

        public bool checkMiniButton = true;

        SaveAndLoadImageManager saveAndLoadImageManager;
        ChatGPT1 chatGPT1;

        private void Start()
        {
            chatGPT1 = GetComponent<ChatGPT1>();
            //saveAndLoadImageManager = FindObjectOfType<SaveAndLoadImageManager>();
            button.onClick.AddListener(SendImageRequest);

        }

        private async void SendImageRequest()
        {
            iconHello.SetActive(false);
            
            
            if(!string.IsNullOrEmpty(inputField.text))
            {
                button.enabled = false;
                inputField.enabled = false;
                checkMiniButton = false;
                image.sprite = null;
                iconImage.enabled = false;
                loadingLabel.SetActive(true);
                iconPoint.SetActive(false);
                iconThink.SetActive(true);

                OpenAIApi openai = new OpenAIApi(chatGPT1.API_Key);

                var response = await openai.CreateImage(new CreateImageRequest
                {
                    Prompt = inputField.text,
                    Size = ImageSize.Size1024
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
                        var sprite = Sprite.Create(texture, new Rect(0, 0, 1024, 1024), Vector2.zero, 1f);
                        image.sprite = sprite;
                        imageBig.sprite = sprite;
                        Debug.Log("Gene complete");

                        //saveButton.SetActive(true);
                        //loadButton.SetActive(true);
                    }
                }
                else
                {
                    Debug.LogWarning("No image was created from this prompt.");
                }

                checkMiniButton = true;
                button.enabled = true;
                inputField.enabled = true;
                loadingLabel.SetActive(false);
                image.gameObject.SetActive(true);
                iconThink.SetActive(false);
                inputField.text = null;
            }
            else
            {
                iconPoint.SetActive(true);
            }
      

        }
    }
}
