using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using Cursor = UnityEngine.Cursor;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameObject creditsMenuGO, tutorialMenuGO, settingsMenuGO;
    [SerializeField] private GameObject playBtn, volumeSaveBtn;
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        Cursor.visible = false;
        if (creditsMenuGO && tutorialMenuGO && settingsMenuGO)
        {
            creditsMenuGO.SetActive(false);
            tutorialMenuGO.SetActive(false);
            settingsMenuGO.SetActive(false);
        }

        LoadVolume();
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

    public void VolumeAdjust()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }

    public void LoadVolume()
    {
        PlayerPrefs.GetFloat("volume", volumeSlider.value);
    }

    public void OpenSettings()
    {
        settingsMenuGO.SetActive(true);
        settingsMenuGO.GetComponentInChildren<Slider>().Select();
    }

    public void CloseSettings()
    {
        settingsMenuGO.SetActive(false);
        EventSystem.current.SetSelectedGameObject(playBtn, new BaseEventData(EventSystem.current));
    }

    public void OpenCredits()
    {
        creditsMenuGO.SetActive(true);
        creditsMenuGO.GetComponentInChildren<Button>().Select();
    }
    
    public void CloseCredits()
    {
        creditsMenuGO.SetActive(false);
        EventSystem.current.SetSelectedGameObject(playBtn, new BaseEventData(EventSystem.current));
    }

    public void OpenTutorial()
    {
        tutorialMenuGO.SetActive(true);
        tutorialMenuGO.GetComponentInChildren<Button>().Select();
    }

    public void CloseTutorial()
    {
        tutorialMenuGO.SetActive(false);
        EventSystem.current.SetSelectedGameObject(playBtn, new BaseEventData(EventSystem.current));
    }
}
