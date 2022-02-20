using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressBar : MonoBehaviour
{

    private Slider slider; 
    
    float time;
 
    public float maxtime; //insert your maxium time

    private bool isSliding = false;

    private void OnEnable()
    {
        slider = gameObject.GetComponent<Slider>();
        SetProgressBar();
    }

    private void SetProgressBar()
    {
        time = 0f;
        slider.maxValue = maxtime;
        isSliding = true;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time < maxtime && isSliding)
        {
            slider.value = time;
        }
        else
        {
            isSliding = false;
        }
    }
}
