using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int currentEnegy;
    [SerializeField] private int enegryThreshold = 3;
    [SerializeField] private GameObject boss;
    private bool bossCalled = false;
    [SerializeField] private GameObject enemySpawn;
    [SerializeField] private Image energyBar;
    [SerializeField] GameObject gameUI; 

    void Start()
    {
        currentEnegy = 0;
        UpdateEnergyBar();
        boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddEnegry()
    {
        if (bossCalled)
        {
            return;
        }
        currentEnegy += 1;
        UpdateEnergyBar();
        if (currentEnegy == enegryThreshold)
        {
            CallBoss();
        }
    }
    private void CallBoss()
    {
        bossCalled = true;
        boss.SetActive(true);
        enemySpawn.SetActive(false);
        gameUI.SetActive(false);
    }
    private void UpdateEnergyBar()
    {
       if(energyBar != null)
        {
            float fillAmount = Mathf.Clamp01((float)currentEnegy / (float)enegryThreshold);
            energyBar.fillAmount = fillAmount;
        }
    }
}
