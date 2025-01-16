using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatalogButtonNextManager : MonoBehaviour
{
    public Button[] buttons;


    public void CloseInteractable()
    {
        for(int i =0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
    }

    public void OpenInteractable()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = true;
        }
    }
}
