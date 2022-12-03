using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elementScript : MonoBehaviour
{
    // Start is called before the first frame update
public bool touchElement = false;
    private void Start()
    {
        touchElement = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        touchElement = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        touchElement = false;
    }

    public bool GetTouchElement()
    {
        return touchElement;
    }
}
