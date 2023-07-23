using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class RewardsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rewardsRecieved;
    [SerializeField] private RewardsManagerSo rewardsManager;
    
    void Start()
    {
        ChangeRewardsRecieved(rewardsManager.Seeds);
    }

    private void OnEnable()
    {
        rewardsManager.seedsChangeEvent.AddListener(ChangeRewardsRecieved);
    }

    private void OnDisable()
    {
        rewardsManager.seedsChangeEvent.RemoveListener(ChangeRewardsRecieved);
    }

    public void ChangeRewardsRecieved(float amount)
    {
        rewardsRecieved.text = "You gained " + amount + " seeds and saved " + 20f + "people";
    }
}