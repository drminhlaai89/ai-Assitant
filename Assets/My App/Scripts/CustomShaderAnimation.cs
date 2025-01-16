using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomShaderAnimation : MonoBehaviour
{
    [SerializeField] private float _myCustomFloat;

    private float __myCustomFloatActualValue;

    private void Awake()
    {
        __myCustomFloatActualValue = GetComponentInChildren<Image>().material.GetFloat("_Cutoff_Height");
    }

    private void LateUpdate()
    {
        if (_myCustomFloat != __myCustomFloatActualValue)
        {              
            __myCustomFloatActualValue = _myCustomFloat;
            GetComponentInChildren<Image>().material.SetFloat("_Cutoff_Height", __myCustomFloatActualValue);
            
        }
    }
}
