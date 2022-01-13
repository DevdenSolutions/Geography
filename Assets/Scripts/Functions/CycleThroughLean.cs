using Lean.Gui;
using UnityEngine;

public class CycleThroughLean : MonoBehaviour
{
    [SerializeField]
    LeanToggle[] Slides;
    int SlideCount;
    int currentSlide = 0;

    private void Start()
    {
        SlideCount = Slides.Length;
        Slides[0].TurnOn();
    }

    public void GoForward()
    {
        if (currentSlide < SlideCount-1)
        {
            currentSlide++;
            TurnSlideOn(currentSlide);
        }
    }

    public void GoBackward()
    {
        if (currentSlide > 0)
        {
            currentSlide--;
            TurnSlideOn(currentSlide);
        }
    }

    void TurnSlideOn(int index)
    {
        Slides[index].TurnOn();
    }
}
