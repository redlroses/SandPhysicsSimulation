using UnityEngine;
using UnityEngine.UI;

public class GradientUIController : MonoBehaviour
{
    public Gradient Gradient;
    public GameObject ColorPanel;
    public RawImage RawImage1;
    public RawImage RawImage2;

    private bool isGrad = false;
    private GradientColorKey[] colorKey;
    private GradientAlphaKey[] alphaKey;

    void Start()
    {
        Gradient = new Gradient();

        colorKey = new GradientColorKey[2];
        colorKey[0].color = RawImage1.color;
        colorKey[0].time = 0.0f;
        colorKey[1].color = RawImage2.color;
        colorKey[1].time = 1.0f;

        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 1.0f;

        Gradient.SetKeys(colorKey, alphaKey);
    }

    private void Update()
    {
        if (isGrad)
        {
            if (RawImage1.color != colorKey[0].color)
            {
                colorKey[0].color = RawImage1.color;
                Gradient.SetKeys(colorKey, alphaKey);
            }

            if (RawImage2.color != colorKey[1].color)
            {
                colorKey[1].color = RawImage2.color;
                Gradient.SetKeys(colorKey, alphaKey);
            }
        }
    }

    public void SetIsGrad(bool flag)
    {
        isGrad = flag;
        ColorPanel.SetActive(flag);
    }
}
