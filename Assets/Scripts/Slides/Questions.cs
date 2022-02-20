using System.Collections.Generic;
using UnityEngine;
using WPM;

public class Questions : MonoBehaviour
{

    #region Singelton
    private static Questions _instance;

    public static Questions Instance { get { return _instance; } }


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
    [SerializeField]
    GameObject[] AllQuestions;
    public List<int> ActivatedCountriesIndex;
    [SerializeField]
    GameObject CountryText2;


    private void Start()
    {

        ActivatedCountriesIndex = new List<int>();
    }
    private void OnEnable()
    {
        map.earthStyle = EARTH_STYLE.Natural;
        map.enableCountryHighlight = true;

        map.SetZoomLevel(1.35f);
        map.allowUserZoom = false;
    }

    private void OnDisable()
    {
        ResetQuestions();
    }
    public void ResetQuestions()
    {
        foreach (var x in QuestionClient.Instance.AllCountryQuestions)
        {
            x.Completed = false;
        }

        for (int i = 0; i < AllQuestions.Length; i++)
        {
                if (AllQuestions[i].activeSelf == false)
                {
                    AllQuestions[i].SetActive(true);
                    AllQuestions[i].transform.GetChild(0).gameObject.SetActive(true);
                    // AllQuestions[i].transform.GetChild(1).gameObject.SetActive(true);
                    AllQuestions[i].transform.GetChild(2).gameObject.SetActive(true);
                    AllQuestions[i].transform.GetChild(3).gameObject.GetComponent<CanvasGroup>().alpha = 1;
                }
            }

        

        for (int i = 0; i < ActivatedCountriesIndex.Count; i++)
        {
            map.ToggleCountrySurface(ActivatedCountriesIndex[i], true, new Color32(0, 0, 0, 0));
        }

        for (int i = 0; i < CountryText2.transform.childCount; i++)
        {
            if (CountryText2.transform.childCount != 0)
            {
                Destroy(CountryText2.transform.GetChild(i).gameObject);
            }
        }
    }



}
