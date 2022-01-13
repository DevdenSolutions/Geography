using TMPro;
using UnityEngine;
using WPM;

public class ShowStateNames : MonoBehaviour
{
    WorldMapGlobe map;
    Province[] province;
    GUIStyle labelStyle, labelStyleShadow;
    public TMP_Text WaterLandtext;
    void Start()
    {
        map = WorldMapGlobe.instance;
        province = map.provinces;
        map.invertZoomDirection = true;
        //printProvince();
       // map.OnProvincePointerDown += (int provinceIndex, int regionIndex) => Debug.Log("Pointer down on province " + map.provinces[provinceIndex].name);
        labelStyle = new GUIStyle();
        labelStyle.alignment = TextAnchor.MiddleCenter;
        labelStyle.normal.textColor = Color.white;
        labelStyleShadow = new GUIStyle(labelStyle);
        labelStyleShadow.normal.textColor = Color.black;
        map.OnCountryPointerDown += PrintCountryIndex;

    }


    void Update()
    {
        if (map.provinceLastClicked != -1)
        {
            //  Debug.LogError(province[map.provinceLastClicked].name);

        }
    }

    void PrintCountryIndex(int countryIndex, int regionIndex)
    {
        //Debug.Log(countryIndex);
    }

    void printProvince()
    {
        foreach (var x in province)
        {
            print(x.name);
        }
    }


}



