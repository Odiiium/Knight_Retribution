using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class SettingsController : MonoBehaviour
{
    internal static bool enableTutorial = true;

    internal float effectsVolume;
    internal float musicVolume;

    [SerializeField] TextMeshProUGUI[] textArray;
    [SerializeField] private Slider effectsSlider;
    [SerializeField] private Slider musicSlider;

    [SerializeField] Toggle tutorialToggle;


    // Initialize slider values as Sound and Music volume. Change Music and Sound volume when drags music and sound sliders
    private void Start()
    {
        tutorialToggle.isOn = enableTutorial;
        effectsSlider.value = Sound.effectsVolume;
        musicSlider.value = MusicThemeController.musicVolume;
        musicSlider.onValueChanged.AddListener(delegate { MusicThemeController.ChangeVolume(musicSlider.value); });
        effectsSlider.onValueChanged.AddListener(delegate { Sound.ChangeEffectsVolume(effectsSlider.value); });
    }


    // Back to Menu
    public void OnMenu()
    {
        SceneManager.LoadScene("MainMenu");
        effectsVolume = effectsSlider.value;
        musicVolume = musicSlider.value;
    }

    public void EnableTutorial(bool condition)
    {
        if (condition)  enableTutorial = true;
        else            enableTutorial = false;
    }
    public void EnableEnglishLanguage()
    {
        PlayerPrefs.SetInt("usedLanguage", 0);
        SwitchLanguage();
    }
    public void EnableUkrainianLanguage()
    {
        PlayerPrefs.SetInt("usedLanguage", 1);
        SwitchLanguage();
    }
    public void EnableRussianLanguage()
    {
        PlayerPrefs.SetInt("usedLanguage", 2);
        SwitchLanguage();
    }

    void SwitchLanguage()
    {
        switch(PlayerPrefs.GetInt("usedLanguage"))
        {
            case 0:
                textArray[0].text = "Enable tutorial";
                textArray[1].text = "Language";
                textArray[2].text = "Russian";
                textArray[3].text = "Ukrainian";
                textArray[4].text = "English";
                break;
            case 1:
                textArray[0].text = "Увімкнути навчання";
                textArray[1].text = "Мова";
                textArray[2].text = "Російська";
                textArray[3].text = "Cуверенна";
                textArray[4].text = "Англійська";
                break;
            case 2:
                textArray[0].text = "Включить обучение";
                textArray[1].text = "Язык";
                textArray[2].text = "Русский";
                textArray[3].text = "Украинский";
                textArray[4].text = "Английский";
                break;
        }
    }



}
