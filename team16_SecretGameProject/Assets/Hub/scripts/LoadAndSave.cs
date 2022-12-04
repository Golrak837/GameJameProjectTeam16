using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAndSave : MonoBehaviour
{
    public static LoadAndSave instance;
    public GameObject Fire;
    public GameObject Void;
    public GameObject Earth;
    public GameObject Wind;
    public GameObject Water;

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
            Destroy(GameObject.Find("teleporterScene1"));
            Fire.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Earth",0)==1)
        {
            EtatElementPlayer.instance.SetElement(2);
            Destroy(GameObject.Find("teleporterScene2"));
            Earth.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Water",0)==1)
        {
            EtatElementPlayer.instance.SetElement(3);
            Destroy(GameObject.Find("teleporterScene3"));
            Water.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Wind",0)==1)
        {
            EtatElementPlayer.instance.SetElement(4);
            Destroy(GameObject.Find("teleporterScene4"));
            Wind.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Void",0)==1)
        {
            EtatElementPlayer.instance.SetElement(5);
            Destroy(GameObject.Find("teleporterScene5"));
            Void.SetActive(true);
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
