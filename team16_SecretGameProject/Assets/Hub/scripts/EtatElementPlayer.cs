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
    public void SetElement(int numeroElement)
    {
        if (numeroElement == 1 && !fire)
        {
            fire = true;
            nbrEtatElement++;
        }else if (numeroElement == 2 && !earth)
        {
            earth = true;
            nbrEtatElement++;
        }else if (numeroElement == 3 && !water)
        {
            water = true;
            nbrEtatElement++;
        }else if (numeroElement == 4 && !wind)
        {
            wind = true;
            nbrEtatElement++;
        }else if (numeroElement == 5 && !voids)
        {
            voids = true;
            nbrEtatElement++;
        }
        else
        {
            Debug.Log("Element deja recuperer");
        }
    }
    
}
