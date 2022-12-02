using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    [SerializeField] public LayerMask playerLayer;
    [SerializeField] public Transform tree;
    private int stateArbre;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (playerLayer != (playerLayer | 1 << col.gameObject.layer)) return;
        int nbrElement;
        var dam = col.gameObject.GetComponent<EtatElementPlayer>();
        if (dam != null)
        {
             nbrElement = dam.nbrEtatElement;
             if (nbrElement > stateArbre)
             {
                 Debug.Log("Etat :" + nbrElement);
                 stateArbre = nbrElement;
                 if(nbrElement==5) Debug.Log("You save the Planet!");
             }
        }
        

    }
}
