using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCombat : MonoBehaviour
{
    [SerializeField] private StaminaLogic2D stamina;
    [SerializeField] private Animator transitionAnim;
    [SerializeField] private GameObject sceneTransition;

    private void Awake()
    {
    }

    public void GoToCombat()
    {
        if (stamina.CheckCanCombat())
        {
            Debug.Log("Can combat");
            stamina.DecreaseStamina();
           // sceneTransition.SetActive(true);
            StartCoroutine(LoadLevel());
        }
        else
        {
            Debug.Log("Cant combat now. Wait a little.");
        }
    }

    IEnumerator LoadLevel()
    {
        //transitionAnim.Play("LevelE");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level 1");
        
    }
    
}
