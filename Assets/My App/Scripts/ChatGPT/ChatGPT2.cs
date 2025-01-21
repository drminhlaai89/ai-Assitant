using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OpenAI
{
    public class ChatGPT2 : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private Button button;
        public TMP_Text textAreaM1;
        public TMP_Text textAreaM2;
        public TMP_Text textAreaM3;

        PlaceDetector placeDetector;

        private OpenAIApi openai = new OpenAIApi("");

        private string userInput;

        public void Awake()
        {

        }
        private void Start()
        {
            placeDetector = FindObjectOfType<PlaceDetector>();
            button.onClick.AddListener(SendReply);
        }
        private async void SendReply()
        {
            if (placeDetector.namePlaces.text == "Museum 1")
            {
                userInput = inputField.text;
                inputField.text = "";
                button.enabled = false;
                inputField.enabled = false;

                // Complete the instruction using ChatCompletion
                var completionResponse = await openai.CreateChatCompletion(new CreateChatCompletionRequest()
                {
                    Model = "gpt-4o-mini",
                    Messages = new List<ChatMessage>()
                    {
                        new ChatMessage() { Role = "system", Content = "Acting as an AI artist try to help Customers find a topic for Dall E, reply in 1 line." },
                        new ChatMessage() { Role = "user", Content = userInput }
                    },
                    MaxTokens = 128
                });

                textAreaM1.text = completionResponse.Choices[0].Message.Content;
            }
            else if (placeDetector.namePlaces.text == "Museum 2")
            {
                userInput = inputField.text;
                inputField.text = "";
                button.enabled = false;
                inputField.enabled = false;

                // Complete the instruction using ChatCompletion
                var completionResponse = await openai.CreateChatCompletion(new CreateChatCompletionRequest()
                {
                    Model = "gpt-4o-mini",
                    Messages = new List<ChatMessage>()
                    {
                        new ChatMessage() { Role = "system", Content = "Acting as an AI artist try to help Customers find a topic for Dall E, reply in 1 line." },
                        new ChatMessage() { Role = "user", Content = userInput }
                    },
                    MaxTokens = 128
                });

                textAreaM2.text = completionResponse.Choices[0].Message.Content;
            }
            else if (placeDetector.namePlaces.text == "Museum 3")
            {
                userInput = inputField.text;
                inputField.text = "";
                button.enabled = false;
                inputField.enabled = false;

                // Complete the instruction using ChatCompletion
                var completionResponse = await openai.CreateChatCompletion(new CreateChatCompletionRequest()
                {
                    Model = "gpt-4o-mini",
                    Messages = new List<ChatMessage>()
                    {
                        new ChatMessage() { Role = "system", Content = "Acting as an AI artist try to help Customers find a topic for Dall E, reply in 1 line." },
                        new ChatMessage() { Role = "user", Content = userInput }
                    },
                    MaxTokens = 128
                });

                textAreaM3.text = completionResponse.Choices[0].Message.Content;
            }

            button.enabled = true;
            inputField.enabled = true;
        }
    }
}
