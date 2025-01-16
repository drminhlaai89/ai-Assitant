using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectFullShowImage : MonoBehaviour
{
    public Image mainIcon;
    public Image icon;
    public void SelectButton()
    {
        icon.sprite = mainIcon.sprite;
    }
}
