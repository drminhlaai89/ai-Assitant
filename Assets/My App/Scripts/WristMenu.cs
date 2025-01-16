using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class WristMenu : MonoBehaviour
{
    public InputActionAsset inputActions;

    public Canvas _wristCanvas;
    public MeshRenderer planeCamera;

    public TMP_Text dateText;
    private InputAction _menu;

    public bool _light = true;
    private void Start()
    {
        _wristCanvas = GetComponent<Canvas>();
        planeCamera = GetComponentInChildren<MeshRenderer>();
        _wristCanvas.enabled = false;
        planeCamera.enabled = false;
        _menu = inputActions.FindActionMap("XRI LeftHand").FindAction("Menu");
        _menu.Enable();
        _menu.performed += ToggleMenu;
        string time = System.DateTime.Now.ToLocalTime().ToString("HH:mm  MM/dd/yyyy");
        dateText.text = time;
    }

    private void OnDestroy()
    {
        _menu.performed -= ToggleMenu;
    }

    public void ToggleMenu(InputAction.CallbackContext context)
    {
        Debug.Log("Buton");
        _wristCanvas.enabled = !_wristCanvas.enabled;
        planeCamera.enabled = !planeCamera.enabled;
    } 
}
