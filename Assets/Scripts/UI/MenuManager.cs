using System;
using System.Collections;
using Unity.VisualScripting;
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

    [Header("Interactables")] 
    [SerializeField] private Button playBtn, resetBtn;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider sensSlider;
    [SerializeField] private GameObject loadScreen;
    private InputManager _inputManager;
    private Animator _animator;
    [Header("Persistent Game Data")] 
    #region Persistent Data

    [SerializeField] private ResourcesContainer resourcesContainer;
    [SerializeField] private CropsContainer cropsContainer;
    [SerializeField] private FloatManagerSo earthLife;
    [SerializeField] private FloatManagerSo stamina;
    [SerializeField] private PlaceableObjectsContainer buildings;
    [SerializeField] private PlaceableObjectsContainer breakables;
    [SerializeField] private RewardsManagerSo rewards;
    #endregion

    private void Start()
    {
        loadScreen.SetActive(false);
        _animator = loadScreen.gameObject.GetComponent<Animator>();
        Cursor.visible = false;
        if (creditsMenuGO && tutorialMenuGO && settingsMenuGO)
        {
            creditsMenuGO.SetActive(false);
            tutorialMenuGO.SetActive(false);
            settingsMenuGO.SetActive(false);
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

    public void NewGame()
    {
        //mainMenuGO.SetActive(false);
        // call data clear function
        ResetGame();
        resetBtn.interactable = false;
    }
    
    public void Play()
    {
        loadScreen.SetActive(true);
        Debug.Log("Play");
        StartCoroutine(LoadGame());
    }

    private void ResetGame()
    {
        resourcesContainer.Reset();
        cropsContainer.Clear();
        earthLife.Reset();
        stamina.Reset();
        buildings.Clear();
        breakables.Clear();
        rewards.Reset();
    }

    public void QuitGame()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }

    // SETTINGS
    
    public void OpenSettings()
    {
        settingsMenuGO.SetActive(true);
        //settingsMenuGO.GetComponentInChildren<Slider>().Select();
    }

    public void CloseSettings()
    {
        settingsMenuGO.SetActive(false);
        /*
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
        */
    }
    
    public void VolumeAdjust()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void SavePrefs()
    {
        PlayerPrefs.SetFloat("volume", AudioListener.volume);
        PlayerPrefs.SetFloat("sensitivity", sensSlider.value);
        CloseSettings();
    }

    // CREDITS
    
    public void OpenCredits()
    {
        creditsMenuGO.SetActive(true);
        //creditsMenuGO.GetComponentInChildren<Button>().Select();
    }
    
    public void CloseCredits()
    {
        creditsMenuGO.SetActive(false);
        //EventSystem.current.SetSelectedGameObject(playBtn, new BaseEventData(EventSystem.current));
    }
    
    // TUTORIAL

    public void OpenTutorial()
    {
        tutorialMenuGO.SetActive(true);
        //tutorialMenuGO.GetComponentInChildren<Button>().Select();
    }

    public void CloseTutorial()
    {
        tutorialMenuGO.SetActive(false);
    }

    IEnumerator LoadGame()
    {
        Debug.Log("enumerator");
        
        _animator.Play("LevelE");
        yield return new WaitForSeconds(1);
        Debug.Log("acabei");
        SceneManager.LoadScene("2DGAME");
    }
}
