using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WPM;

public class Questions : MonoBehaviour
{
    WorldMapGlobe map;

    private void Awake()
    {
        map = WorldMapGlobe.instance;
    }

    private void Start()
    {
       
       
    }
    private void OnEnable()
    {
        map.earthStyle = EARTH_STYLE.Natural;
        map.enableCountryHighlight = true;
       
        map.SetZoomLevel(1.35f);
        map.allowUserZoom = false;
    }
}
