using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPanelController : MonoBehaviour
{
    [SerializeField]
    private float time;

    [SerializeField]
    private GameObject sceneText;

    private void OnEnable()
    {
        StartCoroutine(StartSceneText(time));   
    }

    private void OnDisable()
    {
        sceneText.SetActive(false);
    }

    IEnumerator StartSceneText(float time)
    {
        yield return new WaitForSeconds(time);
        sceneText.SetActive(true);
    }
}
