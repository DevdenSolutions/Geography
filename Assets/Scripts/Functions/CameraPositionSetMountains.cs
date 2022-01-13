using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionSetMountains : MonoBehaviour
{
   
  public void SetCameraPosition()
    {
        Camera.main.transform.position = transform.position;
        Camera.main.transform.rotation = transform.rotation;
    }

   
}
