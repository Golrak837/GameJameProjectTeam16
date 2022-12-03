using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAndSave : MonoBehaviour
{
    public static LoadAndSave instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de LoadAndSave dans la scène");
        }

        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Fire",0)==1)
        {
            EtatElementPlayer.instance.SetElement(1);
        }
        if (PlayerPrefs.GetInt("Earth",0)==1)
        {
            EtatElementPlayer.instance.SetElement(2);
        }
        if (PlayerPrefs.GetInt("Water",0)==1)
        {
            EtatElementPlayer.instance.SetElement(3);
        }
        if (PlayerPrefs.GetInt("Wind",0)==1)
        {
            EtatElementPlayer.instance.SetElement(4);
        }
        if (PlayerPrefs.GetInt("Void",0)==1)
        {
            EtatElementPlayer.instance.SetElement(5);
        }
        TreeController.instance.SetDefaultStateTree(PlayerPrefs.GetInt("TreeStatus",0));
        
    }

    public void SaveFire()
    {
        PlayerPrefs.SetInt("Fire",1);
    }
    
    public void SaveEarth()
    {
        PlayerPrefs.SetInt("Earth",1);
    }
    
    public void SaveWater()
    {
        PlayerPrefs.SetInt("Water",1);
    }
    public void SaveWind()
    {
        PlayerPrefs.SetInt("Wind",1);
    }
    
    public void SaveVoid()
    {
        PlayerPrefs.SetInt("Void",1);
    }

    public void SaveStateTree(int nbreElement)
    {
        PlayerPrefs.SetInt("TreeStatus",nbreElement);
    }
    
}
