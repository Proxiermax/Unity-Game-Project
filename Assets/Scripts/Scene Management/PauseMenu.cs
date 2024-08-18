using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public string pauseSceneName { get; private set; }
    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = PlayerHealth.Instance;
    }

    private void SetPauseState(bool isPaused)
    {
        pauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void Pause()
    {
        SetPauseState(true);
    }

    public void Resume()
    {
        SetPauseState(false);
    }

    public void Restart()
    {
        if (PlayerHealth.Instance != null)
        {
            PlayerHealth.Instance.ResetPlayer();
        }
        else
        {
            Debug.LogError("PlayerHealth instance is null, cannot restart.");
        }
        SetPauseState(false);
    }

    public void BackMenu()
    {
        if (PlayerHealth.Instance != null)
        {
            PlayerHealth.Instance.QuitSuddenly();
        }
        else
        {
            Debug.LogError("PlayerHealth instance is null, cannot quit suddenly.");
            SceneManager.LoadScene("Main Menu");
        }
        SetPauseState(false);
    }

}
