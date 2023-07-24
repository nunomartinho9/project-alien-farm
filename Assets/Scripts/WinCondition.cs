using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private FloatManagerSo enemyCount;
    [SerializeField] private FloatManagerSo playerHealth;
    [SerializeField] private RewardsManagerSo rewards;
    [SerializeField] private FloatManagerSo earthLife;
    [SerializeField] private ResourcesContainer resources;
    
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject looseScreen;
    
    [SerializeField] private Animator animator;
    
    private bool canChangeTime;
    void Start()
    {
        Time.timeScale = 1f;
        canChangeTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount.Value == 20f)
        {
            Debug.Log("GANHEI");
            winScreen.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            earthLife.IncreaseValue(rewards.PopulationGain);
            resources.AddSeeds((int)rewards.Seeds);
            if (canChangeTime)
            {
                Time.timeScale = 0f;
                canChangeTime = false;
            }
        }

        if (playerHealth.Value <= 0)
        {
            looseScreen.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            if (canChangeTime)
            {
                Time.timeScale = 0f;
                canChangeTime = false;
            }
        }
    }

    public void ReturnToBase()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel());
    }
    
    IEnumerator LoadLevel()
    {
        animator.Play("LevelE");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }
}