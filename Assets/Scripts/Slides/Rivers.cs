using UnityEngine;
using WPM;

public class Rivers : MonoBehaviour
{
    [SerializeField]
    Material[] RiverMaterials;
    [SerializeField]
    GameObject[] RiverTexts;
    public bool EnableText = true;
    WorldMapGlobe map;
    public void HighlightRivers(int ID)
    {
        //MakeAllRiverBlue();
        //RiverMaterials[ID].color = Color.red;
        if (EnableText)
        {
            EnablingText(ID);
        }
    }
    private void Awake()
    {
        if (EnableText)
        {
            DisableAllText();
        }
        map = WorldMapGlobe.instance;
       // MakeAllRiverBlue();
    }
    void MakeAllRiverBlue()
    {
        foreach (var x in RiverMaterials)
        {
            x.color = Color.blue;
        }
    }

    void EnablingText(int ID)
    {
        //DisableAllText();
        //RiverTexts[ID].SetActive(true);

    }

    void DisableAllText()
    {
        foreach (var x in RiverTexts)
        {
            x.SetActive(false);
        }
    }

    private void OnEnable()
    {
        RiverStart();
    }

    void RiverStart()
    {
        map.FlyToCountry(map.GetCountryIndex("India"));
        map.earthStyle = EARTH_STYLE.NaturalHighRes16K;
        map.enableCountryHighlight = false;
    }

    private void OnDisable()
    {
        ResetRivers();
    }
    public void ResetRivers()
    {
       for(int i=0;i< HightlightMountainRivers.Instance.RiversActivated.Length; i++)
        {
            HightlightMountainRivers.Instance.RiversActivated[i] = false;
        }

        HightlightMountainRivers.Instance.UnHighlightRiver();
        HightlightMountainRivers.Instance.DisableRiverTexts();
    }
}
