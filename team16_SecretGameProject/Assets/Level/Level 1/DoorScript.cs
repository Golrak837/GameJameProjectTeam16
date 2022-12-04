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
        var dam = collision.gameObject.GetComponent<move_belgian_char>();
        var dam2 = collision.gameObject.GetComponent<move_japanese_char>();
        if (dam != null)
        {
            if (dam.GetHaveKey())
            {
                GameObject.Find("Door").GetComponent<AudioSource>().Play();

                dam.SetHaveKey();
                Destroy(gameObject);
            }
        }else if (dam2 != null)
        {
            if (dam2.GetHaveKey())
            {
                GameObject.Find("Door").GetComponent<AudioSource>().Play();
                dam2.SetHaveKey();
                Destroy(gameObject);
            }
        }
        
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
