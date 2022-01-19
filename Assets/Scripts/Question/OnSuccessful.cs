using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using UnityEngine.UI;
using WPM;

public class OnSuccessful : MonoBehaviour
{
    WorldMapGlobe map;

    private void Awake()
    {
        map = WorldMapGlobe.instance;
    }

    public void AfterSuccesful()
    {
        transform.GetChild(3).gameObject.AddComponent<CanvasGroup>();
        transform.GetChild(3).GetComponent<CanvasGroup>().alphaTransition(0, 1,LeanEase.Smooth);
        transform.GetChild(3).GetComponent<CanvasGroup>().JoinTransition();
        transform.EventTransition(()=>{ gameObject.SetActive(false); }, 0.001f);
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
    }

    public void AfterUnsuccessful()
    {
        transform.GetChild(3).GetChild(0).GetComponent<Image>().colorTransition(Color.red, .5f);
        transform.JoinTransition();
        transform.GetChild(3).GetChild(0).GetComponent<Image>().colorTransition(new Color32(67,67,67,255), 1f);
    }
}
