using Lean.Transition;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WPM;

public class Asia : MonoBehaviour
{
    WorldMapGlobe map;
    [SerializeField]
    TMP_Text AsiaText;
    Vector3 sphereLocation;
    City city;
    Country country;
    [SerializeField]
    List<int> countryList = new List<int>();
    public string Continent;
    [SerializeField]
    GameObject TextPrefab;
    [SerializeField]
    GameObject CountryTextParent;
    Dictionary<int, GameObject> CountryActivated = new Dictionary<int, GameObject>();


    private void Awake()
    {
        map = WorldMapGlobe.instance;
        // map.OnCountryPointerDown += (int countryIndex, int regionIndex) => AsiaText.text =  map.countries[countryIndex].name;

    }

    private void Start()
    {
        EnableObjectsAsia();
    }

    void EnableObjectsAsia()
    {
        map.showProvinces = false;
        map.showCountryNames = false;
        map.allowUserZoom = true;
        
    }

    public void DisableObjectsAsia()
    {
        map.showProvinces = true;
        map.showCountryNames = true;
        map.allowUserZoom = false;
    }
    void PinCountries(int countryIndex, int regionIndex)
    {

        if (countryList == null)
        {
            countryList.Add(countryIndex);
            Pin(countryIndex);
        }
        else
        {
            if (!countryList.Contains(countryIndex))
            {
                countryList.Add(countryIndex);
                Pin(countryIndex);
            }
            else
            {
                GameObject Go;
                CountryActivated.TryGetValue(countryIndex, out Go);
                CountryActivated.Remove(countryIndex);
                countryList.Remove(countryIndex);
                Destroy(GameObject.Find(map.countries[countryIndex].name));
                Destroy(Go);
            }

        }

        if (!countryList.Contains(countryIndex))
        {
            //city = map.cities[countryIndex];
            //country = map.countries[countryIndex];
            //sphereLocation = country.localPosition;
            //GameObject MyPin = Instantiate(Resources.Load<GameObject>("Building/Building"));
            //map.AddMarker(MyPin, sphereLocation, 0.02f);
            //sphereLocation = new Vector3(sphereLocation.x, sphereLocation.y, sphereLocation.z);
            //map.AddText(country.name, sphereLocation, Color.red, 0.02f);

            //Continent = map.countries[countryIndex].continent;

        }

    }

    void Pin(int countryIndex)
    {
        if (map.countries[countryIndex].continent == "Asia" || map.countries[countryIndex].continent == "Eurasia")
        {
            city = map.cities[countryIndex];
            country = map.countries[countryIndex];
            sphereLocation = country.localPosition;
            GameObject MyPin = Instantiate(Resources.Load<GameObject>("Building/Building"));
            map.AddMarker(MyPin, sphereLocation, 0.02f);
            sphereLocation = new Vector3(sphereLocation.x, sphereLocation.y, sphereLocation.z);
            map.AddText(country.name, sphereLocation, Color.red, 0.01f);
            Debug.LogError(map.countries[countryIndex].continent);

            MyPin.transform.GetChild(0).transform.localPositionTransition(Vector3.zero, .5f, LeanEase.Back);
            CountryActivated.Add(countryIndex, MyPin);
            foreach(var x in CountryActivated)
            {
                print("Key: " + x.Key + "Value: " + x.Value);
            }
        }

    }

    public void DisableMarkers()
    {
        GameObject g = GameObject.Find("Markers");
        if (g != null)
        {
            g.SetActive(false);
        }
    }

    private void OnEnable()
    {
        map.OnCountryPointerDown += PinCountries;
        map.FlyToCountry(map.countries[165]);
        map.showFrontiers = true;

        map.enableCountryHighlight = true;
        map.earthStyle = EARTH_STYLE.Natural;
        CountryTextParent.SetActive(true);

    }

    private void OnDisable()
    {
        map.enableCountryHighlight = false;
        map.OnCountryPointerDown -= PinCountries;
        ResetAsiaCountries();
    }

    public void ResetAsiaCountries()
    {
        FindMarkerAndTurnOn.Instance.TurnAllBuildingCloneOFF();
        FindMarkerAndTurnOn.Instance.TurnAllCountryTextOFF();
    }
}
