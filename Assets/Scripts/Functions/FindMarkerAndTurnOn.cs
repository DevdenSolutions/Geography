using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMarkerAndTurnOn : MonoBehaviour
{

    #region Singelton
    private static FindMarkerAndTurnOn _instance;

    public static FindMarkerAndTurnOn Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

    }

    #endregion
    [SerializeField]
     GameObject Marker;
    [SerializeField]
    GameObject CountryText, CountryText2;
    private void Start()
    {
        Invoke("FindMarker", .2f);
    }
    public void FindMarker()
    {
      Marker =  GameObject.Find("Markers");
       
    }

    public void TurnMarkerON()
    {
        Marker.SetActive(true);
    }

    public void TurnMarkerOFF()
    {
        Marker.SetActive(false);
    }

    public void TurnAllBuildingCloneOFF()
    {
       for(int i = 0; i < Marker.transform.childCount; i++)
        {
            print(Marker.transform.GetChild(i).name);
            if (Marker.transform.GetChild(i).name == "Building(Clone)")
            {
                Destroy(Marker.transform.GetChild(i).gameObject);
            }
        }
    }

    public void TurnAllTextOFF()
    {
        for (int i = 0; i < Marker.transform.childCount; i++)
        {
            print(Marker.transform.GetChild(i).name);
            if (Marker.transform.GetChild(i).name == "TextCanvas(Clone)")
            {
                Marker.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public void TurnAllCountryTextOFF()
    {
        for (int i = 0; i < CountryText.transform.childCount; i++)
        {
            Destroy(CountryText.transform.GetChild(i).gameObject);
        }
    }
}

