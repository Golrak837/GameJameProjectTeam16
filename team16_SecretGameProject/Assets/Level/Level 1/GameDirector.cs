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

    [SerializeField] private GameObject element;
    private elementScript elementScript;

    // Start is called before the first frame update
    void Start()
    {
        haveKey = false;

        japanese = Players[0].GetComponent<move_japanese_char>();
        belgian = Players[1].GetComponent<move_belgian_char>();

        elementScript = element.GetComponent<elementScript>();
    }

    // Update is called once per frame
    void Update()
    {
            if(elementScript.GetTouchElement())
            {
                //  Clear
                SceneManager.LoadScene("Hub");
            }
    }
}
