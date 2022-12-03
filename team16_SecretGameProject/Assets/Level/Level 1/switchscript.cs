using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchscript : MonoBehaviour
{
    // Start is called before the first frame update
     public move_japanese_char PlayerA;
     public move_belgian_char PlayerB;
 
     // Use this for initialization
     void Start()
     {
         PlayerA = GameObject.Find("Japanese_char").GetComponent<move_japanese_char>();
         PlayerB = GameObject.Find("Belgian_char").GetComponent<move_belgian_char>();
         PlayerB.GetComponent<move_belgian_char>().enabled = false;
     }
 
     // Update is called once per frame
     void Update()
     {
         if (Input.GetKeyDown("e"))
         {
             PlayerA.GetComponent<move_japanese_char>().enabled = !PlayerA.GetComponent<move_japanese_char>().enabled;
             PlayerB.GetComponent<move_belgian_char>().enabled = !PlayerB.GetComponent<move_belgian_char>().enabled;
         }
     }
}
