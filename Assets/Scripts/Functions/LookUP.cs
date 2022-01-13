using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUP : MonoBehaviour
{
    private void Awake()
    {
        transform.LookAt(Vector3.zero, transform.up);
    }
}
