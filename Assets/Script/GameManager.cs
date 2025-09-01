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

    [SerializeField] GameObject gameMenu;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject gamePause;

    void Start()
    {
        currentEnegy = 0;
        UpdateEnergyBar();
        boss.SetActive(false);
        MainMenu();
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

    private void MainMenu()
    {
        gameMenu.SetActive(true);
        gameOver.SetActive(false);
        gamePause.SetActive(false);
        Time.timeScale = 0f;
    }
   public void GameOverMenu()
    {
        Debug.Log("GameOverMenu ???c g?i");
        Debug.Log("gameOver.activeSelf tr??c khi b?t = " + gameOver.activeSelf);

        gameUI.SetActive(true);
        gameOver.SetActive(true); Debug.Log("gameOver.activeSelf sau khi b?t = " + gameOver.activeSelf);
        gameMenu.SetActive(false);
        gamePause.SetActive(false);
        Time.timeScale = 0f;
    }
    public void PauseGameMenu()
    {
        gamePause.SetActive(true);
        gameOver.SetActive(false);
        gameMenu.SetActive(false);
        Time.timeScale = 0f;
    }
   public void StartGame()
    {
        gamePause.SetActive(false);
        gameOver.SetActive(false);
        gameMenu.SetActive(false);
        Time.timeScale = 1f;
    }
  public void ResumeGame()
    {
        gamePause.SetActive(false);
        gameOver.SetActive(false);
        gameMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
