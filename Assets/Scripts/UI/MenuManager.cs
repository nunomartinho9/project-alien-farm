using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cursor = UnityEngine.Cursor;

public class MenuManager : MonoBehaviour
{
    [Header("Menus")] 
    [SerializeField] private GameObject mainMenuGO;
    [SerializeField] private GameObject creditsMenuGO;
    [SerializeField] private GameObject tutorialMenuGO;
    [SerializeField] private GameObject settingsMenuGO; 
    [SerializeField] private GameObject pauseMenuGO;

    [Header("Interactables")] 
    [SerializeField] private GameObject contBtn, playBtn;
    [SerializeField] private Slider volumeSlider;

    private InputManager _inputManager;
    private bool isPaused;

    private void Awake()
    {
        _inputManager = InputManager.Instance;
        isPaused = false;
    }

    private void Start()
    {
        Cursor.visible = false;
        if (creditsMenuGO && tutorialMenuGO && settingsMenuGO && pauseMenuGO)
        {
            creditsMenuGO.SetActive(false);
            tutorialMenuGO.SetActive(false);
            settingsMenuGO.SetActive(false);
            pauseMenuGO.SetActive(false);
        }
        
        mainMenuGO.SetActive(true);

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
        pauseMenuGO.SetActive(false);
        mainMenuGO.SetActive(true);
    }
    
    public void Play()
    {
        mainMenuGO.SetActive(false);
        
        // call data clear function
        
        SceneManager.LoadScene("2D");
    }

    /*
    public void Pause()
    {
        if (SceneManager.GetActiveScene().name.Equals("2D"))
        {
            if (_inputManager.PlayerPause() && isPaused)
            {
                isPaused = true;
                Time.timeScale = 0;
                pauseMenuGO.SetActive(true);
            }
            else if (_inputManager.PlayerPause() && !isPaused)
            {
                isPaused = false;
                Time.timeScale = 1;
                pauseMenuGO.SetActive(false);
            }
        }

    }
    */

    public void Resume()
    {
        pauseMenuGO.SetActive(false);
    }

    public void Continue()
    {
        mainMenuGO.SetActive(false);
        SceneManager.LoadScene("2D");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // SETTINGS
    
    public void OpenSettings()
    {
        settingsMenuGO.SetActive(true);
        settingsMenuGO.GetComponentInChildren<Slider>().Select();
    }

    public void CloseSettings()
    {
        settingsMenuGO.SetActive(false);
        if (mainMenuGO)
        {
            if (contBtn.GetComponent<Button>().isActiveAndEnabled)
            {
                EventSystem.current.SetSelectedGameObject(contBtn, new BaseEventData(EventSystem.current));
            }
            else
            {
                EventSystem.current.SetSelectedGameObject(playBtn, new BaseEventData(EventSystem.current));
            }
        }
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
        tutorialMenuGO.SetActive(true);
        tutorialMenuGO.GetComponentInChildren<Button>().Select();
    }

    public void CloseTutorial()
    {
        tutorialMenuGO.SetActive(false);
        if (mainMenuGO)
        {
            if (contBtn.GetComponent<Button>().isActiveAndEnabled)
            {
                EventSystem.current.SetSelectedGameObject(contBtn, new BaseEventData(EventSystem.current));
            }
            else
            {
                EventSystem.current.SetSelectedGameObject(playBtn, new BaseEventData(EventSystem.current));
            }        
        }
    }
}
