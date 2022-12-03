using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIKey : MonoBehaviour
{
    public GameObject KeyUI;
    public GameObject JapChar;
    public GameObject BelChar;

    private void Update()
    {
        var key = JapChar.GetComponent<move_japanese_char>();
        var key2 = BelChar.GetComponent<move_belgian_char>();

        if (key.GetHaveKey())
        {
            Debug.Log("Key!");
            KeyUI.SetActive(true);
         }  
        else if (key2.GetHaveKey())
        {
            Debug.Log("Key!");
            KeyUI.SetActive(true);
        }
        else KeyUI.SetActive(false);

        

    }

}
