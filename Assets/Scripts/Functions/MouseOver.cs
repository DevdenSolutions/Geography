using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    public HightlightMountainRivers.MountainTextures currentMountain;
    private void Update()
    {
        
    }
    private void OnMouseOver()
    {
       
        HightlightMountainRivers.Instance.HighlightMountains(transform.name);
    }

    private void OnMouseDown()
    {
       
        HightlightMountainRivers.Instance.EnableMountainText(currentMountain);
    }

    private void OnMouseExit()
    {
        HightlightMountainRivers.Instance.UnHighlight();
    }
}
