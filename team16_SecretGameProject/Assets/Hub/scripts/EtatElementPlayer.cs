using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtatElementPlayer : MonoBehaviour
{
    public int nbrEtatElement;
    private bool fire = false;
    private bool earth = false;
    private bool water = false;
    private bool wind = false;
    private bool voids = false;
    
    public static EtatElementPlayer instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de LoadAndSave dans la scène");
        }

        instance = this;
    }
    public void SetElement(int numeroElement)
    {
        if (numeroElement == 1 && !fire)
        {
            fire = true;
            nbrEtatElement++;
            LoadAndSave.instance.SaveFire();
        }else if (numeroElement == 2 && !earth)
        {
            earth = true;
            nbrEtatElement++;
            LoadAndSave.instance.SaveEarth();
        }else if (numeroElement == 3 && !water)
        {
            water = true;
            nbrEtatElement++;
            LoadAndSave.instance.SaveWater();
        }else if (numeroElement == 4 && !wind)
        {
            wind = true;
            nbrEtatElement++;
            LoadAndSave.instance.SaveWind();
        }else if (numeroElement == 5 && !voids)
        {
            voids = true;
            nbrEtatElement++;
            LoadAndSave.instance.SaveVoid();
        }
        else
        {
            Debug.Log("Element deja recuperer");
        }
    }
    
}
