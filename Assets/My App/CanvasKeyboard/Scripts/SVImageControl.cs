using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit; 

public class SVImageControl : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [SerializeField] private Image pickerImage;
    private RawImage SVImage;
    private ColorPickerControl colorPickerControl;
    private RectTransform rectTransform;
    private RectTransform pickerTransform;

    private bool pointerDown;
    private Vector2 pointerPosition;

    private void Awake()
    {
        SVImage = GetComponent<RawImage>();
        colorPickerControl = FindObjectOfType<ColorPickerControl>();
        rectTransform = GetComponent<RectTransform>();

        pickerTransform = pickerImage.GetComponent<RectTransform>();
        pickerTransform.position = new Vector2(-(rectTransform.sizeDelta.x * 0.5f), -(rectTransform.sizeDelta.y * 0.5f));
    }

    /*void UpdateColor(Vector2 position)
    {
        Vector3 pos = rectTransform.InverseTransformPoint(position);

        float deltaX = rectTransform.sizeDelta.x * 0.5f;
        float deltaY = rectTransform.sizeDelta.y * 0.5f;

        Debug.Log("deltaX " + deltaX);
        Debug.Log("deltaY " + deltaY);

        if (pos.x < -deltaX)
        {
            pos.x = -deltaX;
        }
        else if (pos.x > deltaX)
        {
            pos.x = deltaX;
        }

        if (pos.y < -deltaY)
        {
            pos.y = -deltaY;
        }
        else if (pos.y > deltaY)
        {
            pos.y = deltaY;
        }

        float x = pos.x + deltaX;
        float y = pos.y + deltaY;

        Debug.Log("x " + x);
        Debug.Log("y " + y);

        float xNorm = x / rectTransform.sizeDelta.x;
        float yNorm = y / rectTransform.sizeDelta.y;

        pickerTransform.localPosition = pos;
        pickerImage.color = Color.HSVToRGB(0, 0, 1 - yNorm);

        colorPickerControl.SetSV(xNorm, yNorm);
        Debug.Log("xNorm " + xNorm);
        Debug.Log("yNorm " + yNorm);
    }

    /*public void OnDrag(PointerEventData eventData)
    {
        UpdateColor(eventData);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UpdateColor(eventData);
    } //For normal

    // For VR
    public void OnDrag(PointerEventData eventData)
    {
        pointerPosition = eventData.position;
        UpdateColor(pointerPosition);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        pointerPosition = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerDown = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        pointerDown = eventData.pointerPress != null;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pointerDown = false;
    }

    void Update()
    {
        if (pointerDown)
        {
            UpdateColor(pointerPosition);
        }
    }*/

    public void OnPointerDown(PointerEventData eventData)
    {
        UpdateColor(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateColor(eventData);
    }

    private void UpdateColor(PointerEventData eventData)
    {
        Vector2 localPos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.enterEventCamera, out localPos))
        {
            Vector2 normalizedPos = new Vector2(
                Mathf.InverseLerp(rectTransform.rect.xMin, rectTransform.rect.xMax, localPos.x),
                Mathf.InverseLerp(rectTransform.rect.yMin, rectTransform.rect.yMax, localPos.y)
            );
            colorPickerControl.SetSV(normalizedPos.x, normalizedPos.y);
            pickerTransform.anchoredPosition = localPos;
            
        }
    }
}
