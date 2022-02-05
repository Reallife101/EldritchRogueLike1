using UnityEngine;
using UnityEngine.UI;

public class sliderBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void setSlider(float value)
    {
        slider.value = value;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void sliderMax(float value)
    {
        slider.maxValue = value;
        slider.value = value;

        fill.color = gradient.Evaluate(1f);
    }

    public float getValue()
    {
        return slider.value;
    }
}
