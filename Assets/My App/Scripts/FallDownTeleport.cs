using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDownTeleport : MonoBehaviour
{
    public Transform _transform;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Teleport());
    }

    public void OnTouchTele()
    {
        StartCoroutine(Teleport());
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1);
        player.transform.position = new Vector3(_transform.position.x, _transform.position.y, _transform.position.z);
    }

}
