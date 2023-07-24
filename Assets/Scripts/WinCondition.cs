using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private FloatManagerSo enemyCount;
    [SerializeField] private FloatManagerSo playerHealth;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject looseScreen;
    [SerializeField] private Animator animator;
    void Start()
    {
        Time.timeScale = 1f;
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
            Time.timeScale = 0f;
        }

        if (playerHealth.Value <= 0)
        {
            looseScreen.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
    }

    public void ReturnToBase()
    {
        StartCoroutine(LoadLevel());
    }
    
    IEnumerator LoadLevel()
    {
        animator.Play("LevelE");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("2DMAP 3");//todo: mudar para 1
        
    }
}
