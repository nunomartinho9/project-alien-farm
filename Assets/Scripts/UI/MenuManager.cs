using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using Cursor = UnityEngine.Cursor;

public class MenuManager : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] private GameObject mainMenuGO, creditsMenuGO, tutorialMenuGO, settingsMenuGO;
    
    [Header("Buttons")]
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private GameObject playBtn, volumeSaveBtn;

    private void Start()
    {
        Cursor.visible = false;
        if (creditsMenuGO && tutorialMenuGO && settingsMenuGO)
        {
            creditsMenuGO.SetActive(false);
            tutorialMenuGO.SetActive(false);
            settingsMenuGO.SetActive(false);
        }

        // if player has altered volume settings before
        if (PlayerPrefs.HasKey("volume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("volume");
            volumeSlider.value = AudioListener.volume;
        }
    }

    private void Update()
    {
        if (Input.GetAxis("Cancel") == 1f)
        {
            CloseCredits();
            CloseTutorial();
            CloseSettings();
        }

        if (settingsMenuGO)
        {
            Cursor.visible = true;
            VolumeAdjust();
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PlayLevelOne()
    {
        SceneManager.LoadScene("level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // SETTINGS
    
    public void OpenSettings()
    {
        mainMenuGO.SetActive(false);
        settingsMenuGO.SetActive(true);
        settingsMenuGO.GetComponentInChildren<Slider>().Select();
    }

    public void CloseSettings()
    {
        mainMenuGO.SetActive(true);
        settingsMenuGO.SetActive(false);
        EventSystem.current.SetSelectedGameObject(playBtn, new BaseEventData(EventSystem.current));
    }
    
    public void VolumeAdjust()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("volume", AudioListener.volume);
        CloseSettings();
    }

    // CREDITS
    
    public void OpenCredits()
    {
        mainMenuGO.SetActive(false);
        creditsMenuGO.SetActive(true);
        creditsMenuGO.GetComponentInChildren<Button>().Select();
    }
    
    public void CloseCredits()
    {
        mainMenuGO.SetActive(true);
        creditsMenuGO.SetActive(false);
        EventSystem.current.SetSelectedGameObject(playBtn, new BaseEventData(EventSystem.current));
    }
    
    // TUTORIAL

    public void OpenTutorial()
    {
        mainMenuGO.SetActive(false);
        tutorialMenuGO.SetActive(true);
        tutorialMenuGO.GetComponentInChildren<Button>().Select();
    }

    public void CloseTutorial()
    {
        mainMenuGO.SetActive(true);
        tutorialMenuGO.SetActive(false);
        EventSystem.current.SetSelectedGameObject(playBtn, new BaseEventData(EventSystem.current));
    }
}
