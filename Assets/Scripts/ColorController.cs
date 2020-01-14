using UnityEngine;
using UnityEngine.UI;

public class ColorController : MonoBehaviour
{
    public Color color;
    public RawImage img;
    public SandController sandController;

    void Start()
    {
        color = new Color(1, 1, 1, 1);
    }

    public void SetColorR(float value)
    {
        color.r = value;
        SetColor();
    }

    public void SetColorG(float value)
    {
        color.g = value;
        SetColor();
    }

    public void SetColorB(float value)
    {
        color.b = value;
        SetColor();
    }

    private void SetColor()
    {
        img.color = color;
    }

}
