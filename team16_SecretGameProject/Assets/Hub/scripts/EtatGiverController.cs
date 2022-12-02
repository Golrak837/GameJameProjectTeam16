using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtatGiverController : MonoBehaviour
{
    [SerializeField] public LayerMask playerLayer;
    [SerializeField] public int etat;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (playerLayer != (playerLayer | 1 << col.gameObject.layer)) return;
        var dam = col.gameObject.GetComponent<EtatElementPlayer>();
        dam?.SetElement(etat);
    }
}
