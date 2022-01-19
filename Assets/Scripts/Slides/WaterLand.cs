using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using WPM;

public class WaterLand : MonoBehaviour
{
    GUIStyle labelStyle, labelStyleShadow;
    public TMP_Text WaterLandtext;
    WorldMapGlobe map;
    public GameObject WaterLandUI;
    [SerializeField]
    GameObject WaterLandUIBox;


    private void Awake()
    {
        map = WorldMapGlobe.instance;
    }
    private void Start()
    {
       
        labelStyle = new GUIStyle();
        labelStyle.alignment = TextAnchor.MiddleCenter;
        labelStyle.normal.textColor = Color.white;
        labelStyleShadow = new GUIStyle(labelStyle);
        labelStyleShadow.normal.textColor = Color.black;

    }


    public void EnableObjectsForWaterLand()
    {

        map.showCountryNames = false;
        map.showProvinceCountryOutline = false;
        map.showInlandFrontiers = true;
        map.showFrontiers = false;
        map.enableCountryHighlight = false;
        map.showProvinces = false;


    }

    public void DisableObjectsForWaterLand()
    {
        map.showCountryNames = true;
        map.showProvinceCountryOutline = true;
        map.showInlandFrontiers = false;
        map.showFrontiers = true;
        map.enableCountryHighlight = true;
        map.showProvinces = true;
    }
    string EntityListToString<T>(List<T> entities)
    {
        StringBuilder sb = new StringBuilder("Neighbours: ");
        for (int k = 0; k < entities.Count; k++)
        {
            if (k > 0)
            {
                sb.Append(", ");
            }
            sb.Append(((IAdminEntity)entities[k]).name);
        }
        return sb.ToString();
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
                        if (WaterLandUIBox.activeSelf == false)
                        {
                            WaterLandUIBox.SetActive(true);
                        }
                        WaterLandtext.text = "Land";
                        x = GUIResizer.authoredScreenWidth * (mousePos.x / Screen.width);
                        y = GUIResizer.authoredScreenHeight - (GUIResizer.authoredScreenHeight * (mousePos.y / Screen.height)) - 20 * (Input.touchSupported ? 3 : 1); // slightly up for touch devices
                        GUI.Label(new Rect(x - 1, y - 1, 0, 10), WaterLandtext.text, labelStyleShadow);
                        TextureChanger.Instance.ChangeTexture(TextureChanger.EarthTexture.Earth_Land);
                    }
                    else
                    {
                        Debug.LogError("Water");
                        if (WaterLandUIBox.activeSelf == false)
                        {
                            WaterLandUIBox.SetActive(true);
                        }
                        WaterLandtext.text = "Water";
                        TextureChanger.Instance.ChangeTexture(TextureChanger.EarthTexture.Earth_Water);
                    }
                }

                else
                {
                    WaterLandtext.text = "Nothing";
                   

                }

                text = map.calc.prettyCurrentLatLon;
                x = GUIResizer.authoredScreenWidth / 2.0f;
                y = GUIResizer.authoredScreenHeight - 20;
                GUI.Label(new Rect(x, y, 0, 10), text, labelStyle);
            }
        }
       
    }

    private void Update()
    {
        if (!map.mouseIsOver)
        {
            WaterLandtext.text = "Nothing";
            if (WaterLandUIBox.activeSelf)
            {
                WaterLandUIBox.SetActive(false);
            }
            TextureChanger.Instance.ChangeTexture(TextureChanger.EarthTexture.Earth);
        }
    }

   
}
