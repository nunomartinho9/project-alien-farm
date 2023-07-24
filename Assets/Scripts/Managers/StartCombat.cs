using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCombat : MonoBehaviour
{
    [SerializeField] private StaminaLogic2D stamina;
    [SerializeField] private Animator transitionAnim;
    [SerializeField] private GameObject sceneTransition;
    [SerializeField] private GameObject collectable;
    private GameObject collectableInfo;
    
    
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
            GameObject go = Instantiate(collectable);
        
            collectableInfo = go.transform.GetChild(0).gameObject;
            collectableInfo.GetComponent<TMP_Text>().text = "Can't combat now. Let it recharge";
            collectableInfo.GetComponent<TMP_Text>().color = Color.red;
            Destroy(go, 1.1f);
        }
    }

    IEnumerator LoadLevel()
    {
        transitionAnim.Play("LevelE");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
        
    }
    
}
