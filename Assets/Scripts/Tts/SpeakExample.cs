using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Crosstales.RTVoice;
using UnityEngine.UI;
using System;
using System.Linq;
using TMPro;

public class SpeakExample : MonoBehaviour
{
    private TMP_Text Text;

    [SerializeField]
    private Crosstales.RTVoice.Model.Enum.Gender selectedVoice;

    private void OnEnable()
    {
        Text = GetComponent<TMP_Text>();
        
        Speak();
    }

    private void OnDisable()
    {
        Speaker.Instance.Silence();
    }

    private void Speak()
    {
        if (Speaker.Instance.isVoiceForCultureAvailable("en"))
        {
            Speaker.Instance.Speak(Text.text, voice: Speaker.Instance.VoiceForCulture("en"));
        }
        else
        {
            Speaker.Instance.Speak(Text.text);
        }
    }
}
