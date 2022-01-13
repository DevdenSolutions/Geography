using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WPM;

public class MapSingleton : MonoBehaviour
{
    #region Singelton
    private static MapSingleton _instance;

    public static MapSingleton Instance { get { return _instance; } }


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
    public WorldMapGlobe map;

    
}
