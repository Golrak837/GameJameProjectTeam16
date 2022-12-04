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
    public AudioSource audio;
    public ParticleSystem parts;

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
                         //StartCoroutine(ExampleCoroutine());

        //temp.transform.parent = GameObject.Find("Square (5)").transform;
        //parts.Play();
        if (playerLayer != (playerLayer | 1 << col.gameObject.layer)) return;
        int nbrElement;
        var dam = col.gameObject.GetComponent<EtatElementPlayer>();
        if (dam != null)
        {
             nbrElement = dam.nbrEtatElement;
             Debug.Log(nbrElement);
             if (nbrElement > stateArbre)
             {

                 Debug.Log("Etat :" + nbrElement);
                 stateArbre = nbrElement;
                 LoadAndSave.instance.SaveStateTree(nbrElement);
                 audio.Play();
                 StartCoroutine(ExampleCoroutine());
                 if (nbrElement == 5)
                 {
                     Debug.Log("You save the Planet!");
                     SceneManager.LoadScene("EndingVideo");
                 }
                 
             }
             else
             {
                 Debug.Log("Aucun changement ne semble s'effectuer");
             }
        }
        

    }

    IEnumerator ExampleCoroutine()
        {
            Debug.Log("coroutine");
            ParticleSystem realparts = Instantiate(parts,new Vector3(494, 265, 0), Quaternion.identity);
            realparts.transform.rotation = Quaternion.Euler(-74,94,15);
            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(4);
            Destroy(realparts);


        }

    public void SetDefaultStateTree(int value)
    {
        stateArbre = value;
    }
}
