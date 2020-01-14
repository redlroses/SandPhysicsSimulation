using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class LangManager : MonoBehaviour
{
    public Image langBttnImg;
    public Sprite[] flags;
    public static Lang lng = new Lang();

    private GameObject[] langTexts;
    private string json;
    private int langIndex;
    private string[] langArray = { "ru_RU", "en_US" };

    void Awake()
    {
        if (!PlayerPrefs.HasKey("Language"))
        {
            if (Application.systemLanguage == SystemLanguage.Russian)
                PlayerPrefs.SetString("Language", "ru_RU");
            else PlayerPrefs.SetString("Language", "en_US");
        }
        LangLoad();
        langTexts = GameObject.FindGameObjectsWithTag("localization");
    }
    void Start()
    {
        for (int i = 0; i < langArray.Length; i++)
        {
            if (PlayerPrefs.GetString("Language") == langArray[i])
            {
                langIndex = i + 1;
                langBttnImg.sprite = flags[i];
                break;
            }
        }
        UpdateLang();
    }

    void LangLoad()
    {
        json = File.ReadAllText(Application.streamingAssetsPath + "/Languages/" + PlayerPrefs.GetString("Language") + ".json");
        lng = JsonUtility.FromJson<Lang>(json);
    }
    public void SwitchBttn()
    {
        if (langIndex != langArray.Length) langIndex++;
        else langIndex = 1;
        PlayerPrefs.SetString("Language", langArray[langIndex - 1]);
        langBttnImg.sprite = flags[langIndex - 1];
        LangLoad();
        UpdateLang();
    }

    private void UpdateLang()
    {
        foreach (var item in langTexts)
        {
            item.GetComponent<LangText>().UpdateLang();
        }
    }
}
public class Lang
{
    public string brush;
    public string gravity;
    public string info;
    public string gradient;
    public string color1;
    public string color2;
    public string smoothGrad;
    public string type;
    public string smooth;
    public string random;
}