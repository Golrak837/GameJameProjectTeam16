using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    [SerializeField] private List<GameObject> Players;
    private move_japanese_char japanese;
    private move_belgian_char belgian;

    private bool haveKey = false;

    [SerializeField] private GameObject door;
    private DoorScript doorScript;

    // Start is called before the first frame update
    void Start()
    {
        haveKey = false;

        japanese = Players[0].GetComponent<move_japanese_char>();
        belgian = Players[1].GetComponent<move_belgian_char>();

        doorScript = door.GetComponent<DoorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(haveKey);
        if(!haveKey)
        {
            haveKey = japanese.GetHaveKey();
            if (!haveKey) haveKey = belgian.GetHaveKey();
        }
        else
        {
            if(doorScript.GetTouchDoor() && Input.GetKey(KeyCode.Space))
            {
                //  Clear
                SceneManager.LoadScene("Hub");
            }
        }
    }
}
