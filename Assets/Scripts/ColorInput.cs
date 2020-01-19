using System;
using UnityEngine;
using UnityEngine.UI;

public class ColorInput : MonoBehaviour
{
    private Slider slider;
    private InputField input;

    private void Start()
    {
        slider = GetComponentInParent<Slider>();
        input = GetComponent<InputField>();
    }

    public void SetNumber(string value)
    {
        float number = float.Parse(value);
        if (number > 255)
        {
            number = 255;
        }

        if (number < 0)
        {
            number = 0;
        }
        input.text = number.ToString();
        slider.value = number / 255;
    }

    public void SetField(float value)
    {
        input.text = Mathf.Lerp(0, 255, value).ToString();
    }
}
