using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WPM;

public class Mountains : MonoBehaviour
{
    WorldMapGlobe map;
    private void Awake()
    {
        map = WorldMapGlobe.instance;
    }
    private void OnEnable()
    {
        map.FlyToCountry(map.GetCountryIndex("India"));
        map.SetZoomLevel(.5f);
        map.earthStyle = EARTH_STYLE.NaturalHighRes16K;
        
    }
}
