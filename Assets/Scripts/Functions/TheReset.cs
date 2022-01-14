using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheReset : MonoBehaviour
{
    public GameObject WaterLand, LandMass, Continent, AsiaCountries, Mountains, Rivers, Question;
    
    public void TheMainReset()
    {
        switch (SlideInfo.Instance.CurrentSlide)
        {
            case SlideInfo.Slides.WaterLand:

                break;

            case SlideInfo.Slides.LandMass:
                LandMass.GetComponent<LandMass>().ResetLandMass();
                break;

            case SlideInfo.Slides.Continent:
                
                break;

            case SlideInfo.Slides.AsiaCountries:
                AsiaCountries.GetComponent<Asia>().ResetAsiaCountries();
                break;

            case SlideInfo.Slides.Mountains:
                Mountains.GetComponent<Mountains>().ResetMountains();
                break;

            case SlideInfo.Slides.Rivers:
                Rivers.GetComponent<Rivers>().ResetRivers();
                break;

            case SlideInfo.Slides.Questions:
                Question.GetComponent<Questions>().ResetQuestions();
                break;
        }

        Debug.LogError("Clicked on Reset");
    }
}
