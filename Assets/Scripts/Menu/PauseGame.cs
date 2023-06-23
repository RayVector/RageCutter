using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree;

public class PauseGame : MonoBehaviour
{
    public bool isGamePused = false;
    public GameObject pauseGameUi;
    public PlayerState playerState;
    public AudioSource audioSource;

    private void Awake()
    {
        Resume();
    }

    public void Resume()
    {
        isGamePused = false;
        SetTimeAndCursor(false);
        audioSource.UnPause();
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        isGamePused = true;
        SetTimeAndCursor(true);
        audioSource.Pause();
        Time.timeScale = 0;
    }

    public void SetTimeAndCursor(bool isActive)
    {
        pauseGameUi.SetActive(isActive);
        Cursor.visible = isActive;
        isGamePused = isActive;
    }

    public void MainMenu()
    {
        float savedMaxPoints = SaveGame.Load<float>("_playerMaxPoints");
        if (playerState.points > savedMaxPoints) SaveGame.Save<float>("_playerMaxPoints", playerState.points);
        SceneManager.LoadScene("MainMenu");
    }
}
