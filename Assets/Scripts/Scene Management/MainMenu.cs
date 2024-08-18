using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void PlayLevel01()
    {
        audioManager.PlaySFX(audioManager.click01Sound, 0.2f);
        SceneManager.LoadScene("Lv01-01");
    }

    public void PlayLevel02()
    {
        audioManager.PlaySFX(audioManager.click01Sound, 0.2f);
        SceneManager.LoadScene("Lv02-01");
    }

    public void PlayLevel03()
    {
        audioManager.PlaySFX(audioManager.click01Sound, 0.2f);
        SceneManager.LoadScene("Lv03-01");
    }

    public void CLickSound02()
    {
        audioManager.PlaySFX(audioManager.click02Sound, 0.2f);
    }

    public void CLickSound03()
    {
        audioManager.PlaySFX(audioManager.click03Sound, 0.2f);
    }

    public void QuitGame()
    {
        audioManager.PlaySFX(audioManager.click02Sound, 0.2f);
        Application.Quit();
    }
}
