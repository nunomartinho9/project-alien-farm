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
    private void Start()
    {
        hpManager.Reset();
        enemiesManager.Reset();
        enemiesManager.Set(0);
        ChangeSliderValue(hpManager.Value);
        ChangeTextValue(enemiesManager.Value);
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
    }
    
    public void ChangeTextValue(float amount)
    {
        enemiesKilled.text = amount + "/20";
    }
}
