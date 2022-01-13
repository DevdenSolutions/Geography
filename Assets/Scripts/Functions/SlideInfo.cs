using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideInfo : MonoBehaviour
{
    #region Singelton
    private static SlideInfo _instance;

    public static SlideInfo Instance { get { return _instance; } }


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

    public enum Slides
    {
        WaterLand,
        LandMass,
        Continent,
        AsiaCountries,
        Mountains,
        Rivers,
        Questions
    }

    public Slides CurrentSlide;

    public void SetSlide(int slideNo)
    {
        CurrentSlide = (Slides)slideNo;
    }
}
