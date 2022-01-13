using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Transition;

public class ScaleUI : MonoBehaviour
{
    private void OnEnable()
    {
        transform.localScaleTransition_xy(new Vector2(1, 1), .4f, LeanEase.Decelerate);
    }

    private void OnDisable()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
