using UnityEngine;

public class Rivers : MonoBehaviour
{
    [SerializeField]
    Material[] RiverMaterials;
    [SerializeField]
    GameObject[] RiverTexts;
    public bool EnableText = true;
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
}
