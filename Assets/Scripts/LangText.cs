using UnityEngine;
using UnityEngine.UI;

public class LangText : MonoBehaviour
{
    public string Key;

    private Text text;
    private Lang lang;

    private void Awake()
    {
        text = GetComponent<Text>();
        //Debug.Log(text.text);
    }

    private void Start()
    {
        lang = LangManager.lng;
    }

    public void UpdateLang()
    {
        lang = LangManager.lng;
        switch (Key)
        {
            case "brush":
                text.text = lang.brush;
                break;
            case "gravity":
                text.text = lang.gravity;
                break;
            case "info":
                text.text = lang.info;
                break;
            case "gradient":
                text.text = lang.gradient;
                break;
            case "color":
                text.text = lang.color1;
                break;
            case "color2":
                text.text = lang.color2;
                break;
            case "smoothGrad":
                //Debug.Log(text.text);
                //Debug.Log(lang.smoothGrad);
                text.text = lang.smoothGrad;
                break;
            case "type":
                text.text = lang.type;
                break;
            case "dropdownType":
                Dropdown dropdown = GetComponent<Dropdown>();
                Text lable = dropdown.GetComponentInChildren<Text>();
                if (dropdown.value == 1)
                {
                    lable.text = lang.random;
                }
                else
                {
                    lable.text = lang.smooth;
                }
                dropdown.options[0].text = lang.smooth;
                dropdown.options[1].text = lang.random;
                break;
            default:
                text.text = "ERROR";
                break;
        }
    }
}
