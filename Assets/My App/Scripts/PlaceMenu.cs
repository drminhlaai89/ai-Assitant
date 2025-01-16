using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlaceMenu : MonoBehaviour
{
    public Button sendPalaceButton;
    InputField inputField;
    public TMP_Text textSelect;

    private void Awake()
    {
        inputField = GetComponentInChildren<InputField>();
    }

    private void Start()
    {
        sendPalaceButton.onClick.AddListener(OnClickSendPlace);
    }

    public void OnClickSendPlace()
    {
        textSelect.text = inputField.text;
        inputField.text = "";
    }
}
