using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool touchDoor = false;
    private void Start()
    {
        touchDoor = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        touchDoor = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        touchDoor = false;
    }

    public bool GetTouchDoor()
    {
        return touchDoor;
    }
}
