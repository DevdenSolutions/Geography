using TMPro;
using UnityEngine;
using WPM;

public class LandMass : MonoBehaviour
{
    WorldMapGlobe map;
    [SerializeField]
    TMP_Text LandMassText;

    private void Awake()
    {
        map = WorldMapGlobe.instance;
    }

    void ShowLandMass(int countryIndex, int countryRegion)
    {
        LandMassText.text = map.countries[countryIndex].continent;
        switch (map.countries[countryIndex].continent)
        {
            case "Africa":
                TextureChanger.Instance.ChangeTextureLandMass(TextureChanger.EarthTexture.SouthAfrica);
                if(TextureChanger.Instance.TextureActivated[(int)TextureChanger.EarthTexture.SouthAfrica] == true)
                {
                    InstantiateTexts.Instance.ActivateContinentName(ContinentName.SouthAfrica);
                    Debug.LogError(ContinentName.SouthAfrica);
                }
                else
                {
                    InstantiateTexts.Instance.DeactivateContinentName(ContinentName.SouthAfrica);
                }
                

                break;

            case "South America":
                TextureChanger.Instance.ChangeTextureLandMass(TextureChanger.EarthTexture.SouthAmerica);
               
                if (TextureChanger.Instance.TextureActivated[(int)TextureChanger.EarthTexture.SouthAmerica] == true)
                {
                    InstantiateTexts.Instance.ActivateContinentName(ContinentName.SouthAmerica);
                    Debug.LogError(ContinentName.SouthAmerica);
                }
                else
                {
                    InstantiateTexts.Instance.DeactivateContinentName(ContinentName.SouthAmerica);
                }
                break;

            case "North America":
                TextureChanger.Instance.ChangeTextureLandMass(TextureChanger.EarthTexture.NorthAmerica);
                
                if (TextureChanger.Instance.TextureActivated[(int)TextureChanger.EarthTexture.NorthAmerica] == true)
                {
                    InstantiateTexts.Instance.ActivateContinentName(ContinentName.NorthAmerica);
                    Debug.LogError(ContinentName.NorthAmerica);
                }
                else
                {
                    InstantiateTexts.Instance.DeactivateContinentName(ContinentName.NorthAmerica);
                }
                break;

            case "Asia":
                TextureChanger.Instance.ChangeTextureLandMass(TextureChanger.EarthTexture.Asia);
               
                if (TextureChanger.Instance.TextureActivated[(int)TextureChanger.EarthTexture.Asia] == true)
                {
                    InstantiateTexts.Instance.ActivateContinentName(ContinentName.Eurasia);
                    Debug.LogError(ContinentName.Eurasia);
                }
                else
                {
                    InstantiateTexts.Instance.DeactivateContinentName(ContinentName.Eurasia);
                }
                break;

            case "Oceania":
                TextureChanger.Instance.ChangeTextureLandMass(TextureChanger.EarthTexture.Australia);
               
                if (TextureChanger.Instance.TextureActivated[(int)TextureChanger.EarthTexture.Australia] == true)
                {
                    InstantiateTexts.Instance.ActivateContinentName(ContinentName.Australia);
                    Debug.LogError(ContinentName.Australia);
                }
                else
                {
                    InstantiateTexts.Instance.DeactivateContinentName(ContinentName.Australia);
                }
                break;

            case "Antarctica":
                TextureChanger.Instance.ChangeTextureLandMass(TextureChanger.EarthTexture.Antartica);
                
                if (TextureChanger.Instance.TextureActivated[(int)TextureChanger.EarthTexture.Antartica] == true)
                {
                    InstantiateTexts.Instance.ActivateContinentName(ContinentName.Antarctica);
                    Debug.LogError(ContinentName.Antarctica);
                }
                else
                {
                    InstantiateTexts.Instance.DeactivateContinentName(ContinentName.Antarctica);
                }
                break;

            case "Eurasia":
                TextureChanger.Instance.ChangeTextureLandMass(TextureChanger.EarthTexture.Asia);
               
                if (TextureChanger.Instance.TextureActivated[(int)TextureChanger.EarthTexture.Asia] == true)
                {
                    InstantiateTexts.Instance.ActivateContinentName(ContinentName.Eurasia);
                    Debug.LogError(ContinentName.Eurasia);
                }
                else
                {
                    InstantiateTexts.Instance.DeactivateContinentName(ContinentName.Eurasia);
                }
                break;

            case "Europe":
                TextureChanger.Instance.ChangeTextureLandMass(TextureChanger.EarthTexture.Asia);
               
                if (TextureChanger.Instance.TextureActivated[(int)TextureChanger.EarthTexture.Asia] == true)
                {
                    InstantiateTexts.Instance.ActivateContinentName(ContinentName.Eurasia);
                    Debug.LogError(ContinentName.Eurasia);
                }
                else
                {
                    InstantiateTexts.Instance.DeactivateContinentName(ContinentName.Eurasia);
                }
                break;
        }
    }

    void OnGUI()
    {
        if (gameObject.activeSelf)
        {
            // Do autoresizing of GUI layer
            GUIResizer.AutoResize();

            // Check whether a country or city is selected, then show a label
            if (map.mouseIsOver)
            {
                string text;
                Vector3 mousePos = Input.mousePosition;
                float x, y;

                if (map.mouseIsOver)
                {
                    if (map.countryHighlighted != null || map.cityHighlighted != null || map.provinceHighlighted != null)
                    {
                        //WaterLandtext.text = "Land";
                        x = GUIResizer.authoredScreenWidth * (mousePos.x / Screen.width);
                        y = GUIResizer.authoredScreenHeight - (GUIResizer.authoredScreenHeight * (mousePos.y / Screen.height)) - 20 * (Input.touchSupported ? 3 : 1); // slightly up for touch devices
                                                                                                                                                                      // GUI.Label(new Rect(x - 1, y - 1, 0, 10), WaterLandtext.text, labelStyleShadow);

                        HighlightContinent(map.countryHighlighted.continent);
                    }
                    else
                    {
                        //Debug.LogError("Water");
                        //WaterLandtext.text = "Water";
                        TextureChanger.Instance.HighLightTexture(TextureChanger.EarthTexture.Earth);
                    }
                }

                else
                {
                    // WaterLandtext.text = "Nothing";

                }

                text = map.calc.prettyCurrentLatLon;
                x = GUIResizer.authoredScreenWidth / 2.0f;
                y = GUIResizer.authoredScreenHeight - 20;
                //GUI.Label(new Rect(x, y, 0, 10), text, labelStyle);
            }
        }
       
    }

    void HighlightContinent(string continentName)
    {
        switch (continentName)
        {
            case "Africa":
                //TextureChanger.Instance.ChangeTextureLandMass(TextureChanger.EarthTexture.SouthAfrica);
                //InstantiateTexts.Instance.ActivateContinentName(ContinentName.SouthAfrica);
                TextureChanger.Instance.HighLightTexture(TextureChanger.EarthTexture.SouthAfrica);
               
                break;

            case "South America":
                //TextureChanger.Instance.ChangeTextureLandMass(TextureChanger.EarthTexture.SouthAmerica);
                //InstantiateTexts.Instance.ActivateContinentName(ContinentName.SouthAmerica);
                TextureChanger.Instance.HighLightTexture(TextureChanger.EarthTexture.SouthAmerica);
               
                break;

            case "North America":
                //TextureChanger.Instance.ChangeTextureLandMass(TextureChanger.EarthTexture.NorthAmerica);
                //InstantiateTexts.Instance.ActivateContinentName(ContinentName.NorthAmerica);
                TextureChanger.Instance.HighLightTexture(TextureChanger.EarthTexture.NorthAmerica);
               
                break;

            case "Asia":
                //TextureChanger.Instance.ChangeTextureLandMass(TextureChanger.EarthTexture.Asia);
                //InstantiateTexts.Instance.ActivateContinentName(ContinentName.Eurasia);
                TextureChanger.Instance.HighLightTexture(TextureChanger.EarthTexture.Asia);
               
                break;

            case "Oceania":
                //TextureChanger.Instance.ChangeTextureLandMass(TextureChanger.EarthTexture.Australia);
                //InstantiateTexts.Instance.ActivateContinentName(ContinentName.Australia);
                TextureChanger.Instance.HighLightTexture(TextureChanger.EarthTexture.Australia);
               
                break;

            case "Antarctica":
                //TextureChanger.Instance.ChangeTextureLandMass(TextureChanger.EarthTexture.Antartica);
                //InstantiateTexts.Instance.ActivateContinentName(ContinentName.Antarctica);
                TextureChanger.Instance.HighLightTexture(TextureChanger.EarthTexture.Antartica);
               
                break;

            case "Eurasia":
                //TextureChanger.Instance.ChangeTextureLandMass(TextureChanger.EarthTexture.Asia);
                //InstantiateTexts.Instance.ActivateContinentName(ContinentName.Eurasia);
                TextureChanger.Instance.HighLightTexture(TextureChanger.EarthTexture.Asia);
                
                break;

            case "Europe":
                //TextureChanger.Instance.ChangeTextureLandMass(TextureChanger.EarthTexture.Asia);
                //InstantiateTexts.Instance.ActivateContinentName(ContinentName.Eurasia);
                TextureChanger.Instance.HighLightTexture(TextureChanger.EarthTexture.Asia);
               
                break;
        }
    }
    private void OnEnable()
    {
        map.OnCountryClick += ShowLandMass;

    }

    private void OnDisable()
    {

        map.OnCountryClick -= ShowLandMass;
        ResetLandMass();
    }

    public void EnableLandMassObjects()
    {
        map.showCountryNames = false;
        map.showProvinceCountryOutline = false;
        map.showInlandFrontiers = true;
        map.showFrontiers = false;
        map.enableCountryHighlight = false;
        map.showProvinces = false;
    }

    public void ResetLandMass()
    {
        for(int i =0; i < TextureChanger.Instance.TextureActivated.Length; i++)
        {
            TextureChanger.Instance.TextureActivated[i] = false;
        }
        TextureChanger.Instance.ChangeTextureAlphaToZero();
        FindMarkerAndTurnOn.Instance.TurnAllTextOFF();
        Debug.LogError("Called Reset Land Mass");
    }

    
}
