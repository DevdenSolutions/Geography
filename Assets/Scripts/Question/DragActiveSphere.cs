using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WPM;
using Lean.Transition;

public class DragActiveSphere : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    public int CurrentQuestionNumber = 0;
    public Vector3 InitialPosition;


    WorldMapGlobe map;

    private void Awake()
    {
        map = WorldMapGlobe.instance;
    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        map.allowUserRotation = false;

        gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    private void OnMouseUp()
    {
        map.allowUserRotation = true;
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
                        
                        x = GUIResizer.authoredScreenWidth * (mousePos.x / Screen.width);
                        y = GUIResizer.authoredScreenHeight - (GUIResizer.authoredScreenHeight * (mousePos.y / Screen.height)) - 20 * (Input.touchSupported ? 3 : 1); // slightly up for touch devices
                                                                                                                                                                      // GUI.Label(new Rect(x - 1, y - 1, 0, 10), WaterLandtext.text, labelStyleShadow);

                        print(map.countryHighlighted.name);
                        if (QuestionClient.Instance.AllCountryQuestions[CurrentQuestionNumber].CheckIfRight(map.countryHighlighted.name))
                        {
                            print("It is right brooooo");
                            Successful();
                            QuestionClient.Instance.AllCountryQuestions[CurrentQuestionNumber].Completed = true;
                            HighlightCountry(map.countryHighlightedIndex);
                        }

                        else
                        {
                            print("It is wrong broo");
                            transform.localPosition = InitialPosition;
                            transform.GetComponentInParent<OnSuccessful>().AfterUnsuccessful();
                        }

                    }
                    else
                    {
                        transform.localPosition = InitialPosition;
                    }
                }

                else
                {
                    
                    transform.localPosition = InitialPosition;
                }

                text = map.calc.prettyCurrentLatLon;
                x = GUIResizer.authoredScreenWidth / 2.0f;
                y = GUIResizer.authoredScreenHeight - 20;
                //GUI.Label(new Rect(x, y, 0, 10), text, labelStyle);
            }

            else
            {
                transform.localPosition = InitialPosition;
            }
        }

        gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }

    void Successful()
    {
        transform.GetComponentInParent<OnSuccessful>().AfterSuccesful();
        
    }

    void HighlightCountry(int CountryIndex)
    {
        map.ToggleCountrySurface(CountryIndex, true, new Color32(255, 0, 0, 139));
        map.AddText(map.countries[CountryIndex].name, map.countries[CountryIndex].localPosition, Color.white, 0.017f);
    }
}
