using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool touchDoor = false;
    public AudioSource openSound;
    public AudioSource closedSound;

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
                openSound.Play();

                dam.SetHaveKey();
                StartCoroutine(waitDes());
            }
            else{
            closedSound.Play();
            }

        }else if (dam2 != null)
        {
            if (dam2.GetHaveKey())
            {
                openSound.Play();
                dam2.SetHaveKey();
                StartCoroutine(waitDes());

            }            
            else{
                closedSound.Play();
            }
        }
        
    }

    IEnumerator waitDes()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
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
