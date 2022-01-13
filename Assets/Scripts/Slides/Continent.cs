using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WPM;
using TMPro;

public class Continent : MonoBehaviour
{
    WorldMapGlobe map;
    [SerializeField]
    GameObject TextParent;

    private void Awake()
    {
        map = WorldMapGlobe.instance;

    }

    private void OnEnable()
    {
        map.FlyToCountry(map.countries[165]);
        map.allowUserRotation = false;
        TextureChanger.Instance.ChangeTexture(TextureChanger.EarthTexture.AsiaWithoutEurope);
        InstantiateTexts.Instance.ActivateContinentName(ContinentName.Asia);
        Invoke("EnableUserInteraction",4f);
        
    }
    void OnGUI()
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
                  
                    x = GUIResizer.authoredScreenWidth * (mousePos.x / Screen.width);
                    y = GUIResizer.authoredScreenHeight - (GUIResizer.authoredScreenHeight * (mousePos.y / Screen.height)) - 20 * (Input.touchSupported ? 3 : 1); // slightly up for touch devices
                                                                                                                                                                  // GUI.Label(new Rect(x - 1, y - 1, 0, 10), WaterLandtext.text, labelStyleShadow);

                   if(map.countryHighlighted.continent == "Asia")
                    {
                        TextureChanger.Instance.HighLightTexture(TextureChanger.EarthTexture.AsiaWithoutEurope);
                    }
                }
                else
                {
                   
                    TextureChanger.Instance.EarthModel.GetComponent<MeshRenderer>().materials[2].color = new Color32(255, 255, 255, 139);
                }
            }

            else
            {
                
            }

            text = map.calc.prettyCurrentLatLon;
            x = GUIResizer.authoredScreenWidth / 2.0f;
            y = GUIResizer.authoredScreenHeight - 20;
            //GUI.Label(new Rect(x, y, 0, 10), text, labelStyle);
        }
    }

    public void ChangeTextureBackToOriginal()
    {
        TextureChanger.Instance.ChangeTexture(TextureChanger.EarthTexture.Earth);
    }
    void EnableUserInteraction()
    {
        map.allowUserRotation = true;
    }
}