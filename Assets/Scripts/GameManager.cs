using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject loseMenu;
    public GameObject gameMenu;
    private void Start()
    {
        Application.targetFrameRate = 60;

        Hero.current.health.onDie += () =>
        {
            DeclareLose();
        };

        pauseMenu.SetActive(false);
        loseMenu.SetActive(false);
        gameMenu.SetActive(false);
        mainMenu.SetActive(true);

        Hero.current.controller.enabled = false;
        EnemySpawner.current.enabled = false;
        if (CameraControl.current.cameraFollow)
            CameraControl.current.cameraFollow.enabled = false;
    }

    public void StartGame()
    {
        Hero.current.controller.enabled = true;
        EnemySpawner.current.enabled = true;
        gameMenu.SetActive(true);
        mainMenu.SetActive(false);
        if (CameraControl.current.cameraFollow)
            CameraControl.current.cameraFollow.enabled = true;
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void DeclareLose()
    {
        loseMenu.SetActive(true);
        gameMenu.SetActive(false);
    }
}