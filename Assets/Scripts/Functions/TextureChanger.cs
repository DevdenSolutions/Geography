using UnityEngine;

public class TextureChanger : MonoBehaviour
{
    #region Singelton
    private static TextureChanger _instance;

    public static TextureChanger Instance { get { return _instance; } }


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

    public Texture[] textures;
    public GameObject EarthModel;
    public Texture currentTexture;
    public bool[] TextureActivated;
    public GameObject LandMass;

    private void Start()
    {

    }
    public enum EarthTexture
    {
        Earth,
        Antartica,
        AsiaWithoutEurope,
        Asia,
        Australia,
        Earth_Land,
        Earth_Water,
        NorthAmerica,
        SouthAfrica,
        SouthAmerica,


    }

    public void ChangeTextureAlphaToZero()
    {
        foreach(var x in EarthModel.GetComponent<MeshRenderer>().materials)
        {
            if(x != EarthModel.GetComponent<MeshRenderer>().materials[2])
            {
                x.color = new Color32(255, 255, 255, 0);
            }
        }

        print("Change Texture got called");
    }


    public void ChangeTexture(EarthTexture earthTexture)
    {
        currentTexture = textures[(int)earthTexture];
        //if(EarthModel.GetComponent<MeshRenderer>().material.GetTexture("_MainTex") != currentTexture)
        //{
        //    EarthModel.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", currentTexture);
        //}

        for (int i = 0; i < 10; i++)
        {
            if (i == (int)earthTexture)
            {
                EarthModel.GetComponent<MeshRenderer>().materials[i].color = new Color32(255, 255, 255, 139);
            }

            else
            {
                EarthModel.GetComponent<MeshRenderer>().materials[i].color = new Color32(255, 255, 255, 0);
            }
        }
    }

    public void ChangeTextureLandMass(EarthTexture earthTexture)
    {
        if (LandMass.activeSelf)
        {
            if (EarthModel.GetComponent<MeshRenderer>().materials[(int)earthTexture].color.a == 0)
            {
                EarthModel.GetComponent<MeshRenderer>().materials[(int)earthTexture].color = new Color32(0, 255, 0, 139);
            }

            else
            {
                EarthModel.GetComponent<MeshRenderer>().materials[(int)earthTexture].color = new Color32(0, 255, 0, 0);
            }

            if (TextureActivated[(int)earthTexture] == false)
            {
                TextureActivated[(int)earthTexture] = true;
            }

            else
            {
                TextureActivated[(int)earthTexture] = false;
            }
        }

    }

    public void HighLightTexture(EarthTexture earthTexture)
    {
        for (int i = 0; i < 10; i++)
        {

            if (i == (int)earthTexture)
            {
                if (i != 0)
                {
                    EarthModel.GetComponent<MeshRenderer>().materials[i].color = new Color32(0, 0, 255, 139);
                }
            }

            else
            {
                if (i != 0)
                {
                    if (TextureActivated[i] == true)
                    {
                        if (LandMass.activeSelf)
                        {
                            EarthModel.GetComponent<MeshRenderer>().materials[i].color = new Color32(0, 255, 0, 139);
                        }
                       
                    }

                    else
                    {
                        EarthModel.GetComponent<MeshRenderer>().materials[i].color = new Color32(0, 255, 0, 0);
                    }
                }

                else
                {
                    EarthModel.GetComponent<MeshRenderer>().materials[i].color = new Color32(0, 255, 0, 0);
                }

            }
        }
    }
}
