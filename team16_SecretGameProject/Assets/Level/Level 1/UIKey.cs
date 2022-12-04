using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIKey : MonoBehaviour
{
    public GameObject KeyUIJap;
    public GameObject KeyUIBel;
    public GameObject JapChar;
    public GameObject BelChar;

    private void Update()
    {
        var key = JapChar.GetComponent<move_japanese_char>();
        var key2 = BelChar.GetComponent<move_belgian_char>();

        if (key.GetHaveKey())
        {
            Debug.Log("Key!");
            KeyUIJap.SetActive(true);
        }
        else
        {
            KeyUIJap.SetActive(false);
        }
        if (key2.GetHaveKey())
        {
            Debug.Log("Key!");
            KeyUIBel.SetActive(true);
        }
        else
        {
            KeyUIBel.SetActive(false);
        }

        

    }

}
