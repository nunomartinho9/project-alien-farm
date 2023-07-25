using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;

public class UiManager3d : MonoBehaviour
{
    [SerializeField] private Slider hpSlider;
    [SerializeField] private TextMeshProUGUI enemiesKilled;
    [SerializeField] private FloatManagerSo hpManager;
    [SerializeField] private FloatManagerSo enemiesManager;
    public SoundEffectSo hitSound;
    
    [Header("Pause")] 
    [SerializeField] private GameObject pauseScreen;
    private bool isPaused;
    private InputManager inputManager;
    
    [Header("Win")] 
    [SerializeField] private GameObject winScreen;
    
    [Header("Lose")] 
    [SerializeField] private GameObject loseScreen;    
    private void Start()
    {
        hpManager.Reset();
        enemiesManager.Reset();
        enemiesManager.Set(0);
        ChangeSliderValue(hpManager.Value);
        ChangeTextValue(enemiesManager.Value);
        inputManager = InputManager.Instance;
        isPaused = false;
        pauseScreen.SetActive(false);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    private void Update()
    {
        PauseGame();
        WinGame();
        LoseGame();
    }

    private void OnEnable()
    {
        hpManager.floatChangeEvent.AddListener(ChangeSliderValue);
        enemiesManager.floatChangeEvent.AddListener(ChangeTextValue);
    }
    
    private void OnDisable()
    {
        hpManager.floatChangeEvent.RemoveListener(ChangeSliderValue);
        enemiesManager.floatChangeEvent.RemoveListener(ChangeTextValue);
    }

    public void ChangeSliderValue(float amount)
    {
        hpSlider.value = amount;
        hitSound.Play();

    }
    
    public void ChangeTextValue(float amount)
    {
        enemiesKilled.text = amount + "/20";
    }
    
    public void PauseGame()
    {
        if (inputManager.PlayerPause() && !isPaused)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
            isPaused = !isPaused;
        }
        else if (inputManager.PlayerPause() && isPaused)
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
            isPaused = !isPaused;
        }
    }

    private void WinGame()
    {
        /*if (allEnemiesKilled)
        {
        Time.timeScale = 0;
        winScreen.SetActive(true);
        }*/
    }
    
    private void LoseGame()
    {
        /*if (PlayerDead)
        {
        Time.timeScale = 0;
        loseScreen.SetActive(true);
        }*/
    }
}
