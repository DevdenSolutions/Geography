using Lean.Gui;
using Lean.Transition.Method;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CycleThroughLean : MonoBehaviour
{
    [SerializeField]
    LeanToggle[] Slides;
    int SlideCount;
    int currentSlide = 0;
    public Transform listParent;
    public LeanGameObjectSetActive leanGameObjectSetActiveTransition;
    public List<string> title;
    public List<AudioClip> audioClips;
    public AudioSource audioSource;
    private void Start()
    {
        SlideCount = Slides.Length;
        Slides[0].TurnOn();

        for (int i = 0; i < 6; i++)
        {
            int k = i;
            listParent.GetChild(k).GetComponent<Button>().onClick.AddListener(() => { TurnSlideOn(k); print(123); });
            listParent.GetChild(k).GetChild(0).GetComponent<TextMeshProUGUI>().text = (k + 1) + ". " + title[k];
        }
        ChangeListBgColor();
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }

    public void GoForward()
    {
        if (currentSlide < SlideCount-1)
        {
            currentSlide++;

            TurnSlideOn(currentSlide);
        }
        ChangeListBgColor();
    }

    public void GoBackward()
    {
        if (currentSlide > 0)
        {
            currentSlide--;
            TurnSlideOn(currentSlide);
        }
        ChangeListBgColor();
    }

    void TurnSlideOn(int index)
    {
        currentSlide = index;
        Slides[index].TurnOn();
        ChangeListBgColor();
        leanGameObjectSetActiveTransition.BeginAllTransitions();
        try
        {
            if (audioClips[index])
            {
                audioSource.clip = audioClips[index];
                audioSource.Play();
            }
        }
        catch{ }
    }


    public void ChangeListBgColor()
    {
        for (int i = 0; i < 6; i++)
        {
            listParent.GetChild(i).GetChild(0).GetComponent<LeanGraphicColor>().BeginThisTransition();
        }
        try
        {
            listParent.GetChild(currentSlide).GetComponent<LeanGraphicColor>().BeginThisTransition();
            print(000);
        }
        catch { }
    }

    public void ChangeCurrentBgColor()
    {
        try
        {
            listParent.GetChild(currentSlide).GetComponent<LeanGraphicColor>().BeginThisTransition();
            print(000);
        }
        catch { }
    }


}
