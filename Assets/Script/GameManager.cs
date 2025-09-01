using Unity.Cinemachine;
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

    [SerializeField] private GameObject gameMenu;
    [SerializeField] private GameObject gameOver;
    [SerializeField]  private GameObject gamePause;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private CinemachineCamera cam; 

    [SerializeField] private AudioManager audioManager;

    void Start()
    {
        currentEnegy = 0;
        UpdateEnergyBar();
        boss.SetActive(false);
        MainMenu();
        audioManager.StopAudioGame();
        cam.Lens.OrthographicSize = 5f;
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
        audioManager.playBossAudio();
        cam.Lens.OrthographicSize = 10f;
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
        winMenu.SetActive(false);
        Time.timeScale = 0f;
    }
   public void GameOverMenu()
    {
    

        gameUI.SetActive(true);
        gameOver.SetActive(true);  
        gameMenu.SetActive(false);
        gamePause.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public void PauseGameMenu()
    {
        gamePause.SetActive(true);
        gameOver.SetActive(false);
        gameMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 0f;
    }
   public void StartGame()
    {
        gamePause.SetActive(false);
        gameOver.SetActive(false);
        gameMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 1f;
        audioManager.playDefaultAudio();
    }
  public void ResumeGame()
    {
        gamePause.SetActive(false);
        gameOver.SetActive(false);
        gameMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void winGameMenu() {
        gamePause.SetActive(false);
        gameOver.SetActive(false);
        gameMenu.SetActive(false);
        winMenu.SetActive(true );
        Time.timeScale = 0f;
    }

}
