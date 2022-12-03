using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class switchscript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject camera;
    [SerializeField] public GameObject camera2;
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

             camera.GetComponent<CinemachineVirtualCamera>().enabled =
                 !camera.GetComponent<CinemachineVirtualCamera>().enabled;
             camera2.GetComponent<CinemachineVirtualCamera>().enabled =
                 !camera2.GetComponent<CinemachineVirtualCamera>().enabled;
             PlayerA.GetComponent<move_japanese_char>().enabled = !PlayerA.GetComponent<move_japanese_char>().enabled;
             PlayerB.GetComponent<move_belgian_char>().enabled = !PlayerB.GetComponent<move_belgian_char>().enabled;
         }
     }
}
