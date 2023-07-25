using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame2D : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu, darkbg;
    private bool isPaused;
    
    public void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            darkbg.SetActive(true);
            isPaused = !isPaused;
        }
        else if (isPaused)
        {
            pauseMenu.SetActive(false);
            darkbg.SetActive(false);
            Time.timeScale = 1;
            isPaused = !isPaused;
        }
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("MENUS");
    }
}
