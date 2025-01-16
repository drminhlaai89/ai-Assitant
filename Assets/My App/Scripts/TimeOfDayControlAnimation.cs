using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeOfDayControlAnimation : MonoBehaviour
{
    public Color32 oldColor;
    public Color32 edgeColor;

    public Animator animator;

    private void Awake()
    {
        oldColor = GetComponentInChildren<Image>().material.GetColor("_Base_Color");
        edgeColor = GetComponentInChildren<Image>().material.GetColor("_Edge_Color");
    }

    public void OnClickButtonChooseTimeOfDay(Button _button)
    {
        animator.Play("Empty");
        ButtonTimeOfDay buttonTimeOfDay;
        buttonTimeOfDay = _button.GetComponent<ButtonTimeOfDay>();
        if (buttonTimeOfDay != null)
        {
            edgeColor = oldColor;
            GetComponentInChildren<Image>().material.SetColor("_Edge_Color", edgeColor);
            oldColor = buttonTimeOfDay.newColor;
            GetComponentInChildren<Image>().material.SetColor("_Base_Color", oldColor);
            animator.Play("TimeOfDay");
        }
        else
        {
            Debug.Log("No button");
        }    
    }    
}
