using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtatGiverController : MonoBehaviour
{
    [SerializeField] public LayerMask playerLayer;
    [SerializeField] public LayerMask player2Layer;
    [SerializeField] public int etat;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D col)
    {
        if ((playerLayer != (playerLayer | 1 << col.gameObject.layer))&&(player2Layer != (player2Layer | 1 << col.gameObject.layer))) return;
        EtatElementPlayer.instance.SetElement(etat);
        
    }
}
