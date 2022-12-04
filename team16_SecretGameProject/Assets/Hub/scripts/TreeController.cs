using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeController : MonoBehaviour
{
    [SerializeField] public LayerMask playerLayer;
    [SerializeField] public Transform tree;
    private int stateArbre;
    public static TreeController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de LoadAndSave dans la scène");
        }

        instance = this;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (playerLayer != (playerLayer | 1 << col.gameObject.layer)) return;
        int nbrElement;
        var dam = col.gameObject.GetComponent<EtatElementPlayer>();
        if (dam != null)
        {
             nbrElement = dam.nbrEtatElement;
             Debug.Log("You have" );
             Debug.Log(nbrElement);
             if (nbrElement > stateArbre)
             {
                 Debug.Log("Etat :" + nbrElement);
                 stateArbre = nbrElement;
                 LoadAndSave.instance.SaveStateTree(nbrElement);
                 if (nbrElement == 5)
                 {
                     Debug.Log("You save the Planet!");
                     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
                 }
                 
             }
             else
             {
                 Debug.Log("Aucun changement ne semble s'effectuer");
             }
        }
        

    }

    public void SetDefaultStateTree(int value)
    {
        stateArbre = value;
    }
}
