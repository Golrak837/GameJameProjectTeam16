using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporHanddler : MonoBehaviour
{
    [SerializeField] public LayerMask playerLayer;
    [SerializeField] public int sceneOrder;
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (playerLayer != (playerLayer | 1 << col.gameObject.layer)) return;
        if (sceneOrder <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneOrder);
        }

    }

}
