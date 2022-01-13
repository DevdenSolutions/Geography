using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererUpdater : MonoBehaviour
{
    public GameObject ActiveSphere, PassiveSphere;
    public LineRenderer lineRenderer;
    Vector3 Point1, Point2;

    private void Start()
    {
       
    }

    private void Update()
    {
        Point1 = ActiveSphere.transform.position;
        Point2 = PassiveSphere.transform.position;
        lineRenderer.SetPosition(0, Point1);
        lineRenderer.SetPosition(1, Point2);

    }
    private void OnEnable()
    {
        
    }
}
