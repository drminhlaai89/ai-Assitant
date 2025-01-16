using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPopupManager : MonoBehaviour
{
    public Transform head;
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * 2;
    }
}
