using UnityEngine;

public class HightlightMountainRivers : MonoBehaviour
{
    #region Singelton
    private static HightlightMountainRivers _instance;

    public static HightlightMountainRivers Instance { get { return _instance; } }


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


    public GameObject EarthModelMountains;
    public GameObject EarthModelRivers;
    public bool[] MountainActivated;
    public bool[] RiversActivated;
    public Camera cam;
    public GameObject[] MountainTexts;
    public GameObject[] RiverTexts;

    [Space(5)]
    [Header("Change Color Here")]
    [Space(5)] public Color32 MountainHighlightedColor;
    [Space(5)] public Color32 RiverHighlightColor;
    [Space(5)] public Color32 MountainNormalColor;
    [Space(5)] public Color32 MountainClickedColor;
    [Space(5)] public Color32 RiverClickedColor;
    [Space(5)] public Color32 RiverNormalColor;

    public enum MountainTextures
    {
        Earth,
        Altai,
        Caucasus,
        Himalayas,
        HinduKush,
        Karakoram,
        Kunlun,
        Pamir,
        Tianshan,
        Ural,
        WesternGhats
    }

    public enum RiverNames
    {
        Earth,
        Amur,
        Brahmaputra,
        Ganga,
        Indus,
        Baikal,
        Mekong,
        OB,
        Yangtze,
        YellowRiver,
        YellowSea
    }

    private void Start()
    {
        
    }

    void InitializeRiverColorToNormal()
    {
        int counter = 0;
        foreach(var x in EarthModelRivers.GetComponent<MeshRenderer>().materials)
        {
            if (counter != 0)
            {
                x.color = RiverNormalColor;
               
            }
            counter++;
        }
    }
    public void HighlightMountains(string Name)
    {
        switch (Name)
        {
            case "Himalayas":
                MountainHighlighting(MountainTextures.Himalayas);
                break;

            case "WesternGhats":
                MountainHighlighting(MountainTextures.WesternGhats);
                break;

            case "Altai":
                MountainHighlighting(MountainTextures.Altai);
                break;

            case "Kunlun Mountain":
                MountainHighlighting(MountainTextures.Kunlun);
                break;

            case "HinduKush":
                MountainHighlighting(MountainTextures.HinduKush);
                break;

            case "Ural Mountains":
                MountainHighlighting(MountainTextures.Ural);
                break;

            case "Pamir Mountains":
                MountainHighlighting(MountainTextures.Pamir);
                break;

            case "TianShan":
                MountainHighlighting(MountainTextures.Tianshan);
                break;

            case "Caucasus Mountain":
                MountainHighlighting(MountainTextures.Caucasus);
                break;

            case "Karakoram":
                MountainHighlighting(MountainTextures.Karakoram);
                break;
        }
    }

    void MountainHighlighting(MountainTextures mountainTextures)
    {
        for (int i = 0; i < 11; i++)
        {
            if (i != 0)
            {

                if (i == (int)mountainTextures)
                    EarthModelMountains.GetComponent<MeshRenderer>().materials[(int)mountainTextures].color = MountainHighlightedColor;
                else
                {
                    if (MountainActivated[i] == false)
                        EarthModelMountains.GetComponent<MeshRenderer>().materials[i].color = MountainNormalColor;
                    else
                    {
                        EarthModelMountains.GetComponent<MeshRenderer>().materials[i].color = MountainClickedColor;
                    }
                }
            }


        }
    }

    public void UnHighlight()
    {
        for (int i = 0; i < 11; i++)
        {
            if (i != 0)
            {
                if (MountainActivated[i] == false)
                    EarthModelMountains.GetComponent<MeshRenderer>().materials[i].color = MountainNormalColor;
                else
                {
                    EarthModelMountains.GetComponent<MeshRenderer>().materials[i].color = MountainClickedColor;
                }
            }

        }
    }


    public void HighlightRivers(string River)
    {
        switch (River)
        {
            case "Indus River":
                HighlightingRivers(RiverNames.Indus);
                break;

            case "Ganges":
                HighlightingRivers(RiverNames.Ganga);
                break;

            case "Brahmaputra":
                HighlightingRivers(RiverNames.Brahmaputra);
                break;

            case "Amur":
                HighlightingRivers(RiverNames.Amur);
                break;

            case "Lake Baikal":
                HighlightingRivers(RiverNames.Baikal);
                break;

            case "Mekong River":
                HighlightingRivers(RiverNames.Mekong);
                break;

            case "Mekong River (1)":
                HighlightingRivers(RiverNames.Mekong);
                break;

            case "OB River":
                HighlightingRivers(RiverNames.OB);
                break;

            case "Yangtze River":
                HighlightingRivers(RiverNames.Yangtze);
                break;

            case "Yellow River":
                HighlightingRivers(RiverNames.YellowRiver);
                break;

            case "Yellow Sea":
                HighlightingRivers(RiverNames.YellowSea);
                break;
        }
    }

    void HighlightingRivers(RiverNames riverNames)
    {
        for (int i = 0; i < 11; i++)
        {
            if (i != 0)
            {

                if (i == (int)riverNames)
                    EarthModelRivers.GetComponent<MeshRenderer>().materials[(int)riverNames].color = RiverHighlightColor;
                else
                {
                    if (RiversActivated[i] == false)
                        EarthModelRivers.GetComponent<MeshRenderer>().materials[i].color = RiverNormalColor;
                    else
                    {
                        EarthModelRivers.GetComponent<MeshRenderer>().materials[i].color = RiverClickedColor;
                    }
                }
            }
        }
    }


    public void UnHighlightRiver()
    {
        for (int i = 0; i < 11; i++)
        {
            if (i != 0)
            {
                if(RiversActivated[i] == false)
                {
                    EarthModelRivers.GetComponent<MeshRenderer>().materials[i].color = RiverNormalColor;
                }
                else
                {
                    EarthModelRivers.GetComponent<MeshRenderer>().materials[i].color = RiverClickedColor;
                }
            }
        }
    }
    public void EnableMountainText(MountainTextures mountainName)
    {
        if (MountainActivated[(int)mountainName] == false)
        {
            MountainActivated[(int)mountainName] = true;
            MountainTexts[(int)mountainName].SetActive(true);
        }
        else
        {
            MountainActivated[(int)mountainName] = false;
            MountainTexts[(int)mountainName].SetActive(false);
        }
    }

    public void EnableRiverText(RiverNames riverNames)
    {
        if (RiversActivated[(int)riverNames] == false)
        {
            RiversActivated[(int)riverNames] = true;
            RiverTexts[(int)riverNames].SetActive(true);
        }
        else
        {
            RiversActivated[(int)riverNames] = false;
            RiverTexts[(int)riverNames].SetActive(false);
        }
    }
}
