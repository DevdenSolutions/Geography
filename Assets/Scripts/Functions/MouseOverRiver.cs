using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverRiver : MonoBehaviour
{
    public HightlightMountainRivers.RiverNames CurrentRiver;
    private void OnMouseOver()
    {
        HightlightMountainRivers.Instance.HighlightRivers(transform.name);
        print(transform.name);
    }

    private void OnMouseDown()
    {
        HightlightMountainRivers.Instance.EnableRiverText(CurrentRiver);
    }
    private void OnMouseExit()
    {
        HightlightMountainRivers.Instance.UnHighlightRiver();
    }
}
