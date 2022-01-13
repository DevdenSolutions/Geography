using TMPro;
using UnityEngine;
using WPM;

public class InstantiateTexts : MonoBehaviour
{

    #region Singelton
    private static InstantiateTexts _instance;

    public static InstantiateTexts Instance { get { return _instance; } }


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


        map = WorldMapGlobe.instance;

    }

    #endregion

    WorldMapGlobe map;
    public GameObject Asia, Eurasia, Antarctica, Australia, NorthAmerica, SouthAmerica, SouthAfrica;
    public GameObject TextPrefab;
    public GameObject[] Continents;
    public int counter;


    private void Start()
    {
        Continents = new GameObject[] { Asia, Eurasia, Antarctica, Australia, NorthAmerica, SouthAmerica, SouthAfrica };
        InstantiateAllTexts();
    }
    void InstantiateAllTexts()
    {

        MainInstantiate(165, "Asia");
        MainInstantiate(127, "South Africa");
        MainInstantiate(171, "South America");
        MainInstantiate(168, "Australia");
        MainInstantiate(175, "Antarctica");
        MainInstantiate(169, "North America");
        MainInstantiate(165, "Eurasia");
    }

    void MainInstantiate(int CountryIndex, string continentName, GameObject _GO = null)
    {

       
        Continents[counter] = Instantiate(TextPrefab);
        Continents[counter].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = continentName;
        map.AddMarker(Continents[counter], map.countries[CountryIndex].localPosition, 0.001f, true);
        Continents[counter].transform.LookAt(transform.position, transform.up);
        Continents[counter].SetActive(false);
        counter++;

    }

    public void ActivateContinentName(ContinentName continentName)
    {
        int counter = 0;

        foreach (var x in Continents)
        {
            if (counter == (int)continentName)
            {
                x.SetActive(true);
            }

            counter++;
        }
    }

    public void DeactivateContinentName(ContinentName continentName)
    {
        int counter = 0;

        foreach (var x in Continents)
        {
            if (counter == (int)continentName)
            {
                x.SetActive(false);
            }
            counter++;
        }
    }  

    public void DisableAllContinentName()
    {
        foreach(var x in Continents)
        {
            if(x != Continents[0])
            {
                x.SetActive(false);
            }
           
        }
    }
    public void EnableAfrica()
    {
        ActivateContinentName(ContinentName.SouthAfrica);
    }

    public void DisableAsia()
    {
        Continents[0].SetActive(false);
    }

   
}

public enum ContinentName
{
    Asia,
    SouthAfrica,
    SouthAmerica,
    Australia,
    Antarctica,
    NorthAmerica,
    Eurasia
}
