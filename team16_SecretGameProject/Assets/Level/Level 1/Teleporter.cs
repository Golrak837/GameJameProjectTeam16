using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform tpPos;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player detected");
            other.transform.position = new Vector2(tpPos.position.x, tpPos.position.y);
        }
    }
}
