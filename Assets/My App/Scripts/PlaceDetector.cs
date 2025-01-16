using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaceDetector : MonoBehaviour
{
    public string namePlace;
    public TMP_Text namePlaces;

    public GameObject[] placeObject;
    public GameObject[] buttonPlaceObj;

    public Transform _transform;
    public GameObject player;

   
    private void LateUpdate()
    {
        namePlaces.text = namePlace;
    }


    public void OnClickPlace(GameObject _button)
    {
        namePlaces.text = namePlace;

        for (int i = 0; i < buttonPlaceObj.Length; i++)
        {
            if(_button == buttonPlaceObj[i])
            {
                placeObject[i].SetActive(true);
            }
            else
            {
                placeObject[i].SetActive(false);
            }
        }

        player.transform.position = new Vector3(_transform.position.x, _transform.position.y, _transform.position.z);
    }

    }
