using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlaceEventCatalog : MonoBehaviour
{
    public TMP_Text placeType;
    public Button sendPalaceButton;
    InputField inputField;

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
        placeType.text = inputField.text;
        inputField.text = "";
    }

    public void OnClickLocation(string _buttonText)
    {
        placeType.text = _buttonText;
    }
}
