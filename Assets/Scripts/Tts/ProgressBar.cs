using UnityEngine;
using UnityEngine.UI;
using Crosstales.RTVoice;
using System.Collections;

public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text current_text;

    private Slider slider; 
    
    float time;
    float maxtime; //insert your maxium time

    private bool isSliding = false;

    private void OnEnable()
    {
        slider = gameObject.GetComponent<Slider>();
        //  Speaker.OnSpeakStart += Speaker_OnSpeakStart;
        SetProgressBar();
    }

    private void Speaker_OnSpeakStart(Crosstales.RTVoice.Model.Wrapper wrapper)
    {
        SetProgressBar();
    }

    private void SetProgressBar()
    {
        time = 0f;
        slider.maxValue = Speaker.Instance.ApproximateSpeechLength(current_text.text);
        maxtime = slider.maxValue;
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
