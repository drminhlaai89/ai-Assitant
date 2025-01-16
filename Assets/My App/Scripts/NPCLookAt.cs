using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLookAt : MonoBehaviour
{
    public Transform target;
    public GameObject dialougeChat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPostition = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(targetPostition);

        if (Vector3.Distance(transform.position, target.position) <= 4f)
        {
            dialougeChat.SetActive(true);
        }
        else
        {
            dialougeChat.SetActive(false);
        }
    }
}
