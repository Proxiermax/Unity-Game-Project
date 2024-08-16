using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour
{
    private string winAtLevel;

    private void Start()
    {
        winAtLevel = PlayerPrefs.GetString("WinAtLevel");
        Debug.Log($"Win Level : {winAtLevel}");
    }

    public void NextLevel()
    {
        if (winAtLevel == "Lv01-01" || winAtLevel == "Lv01-02" || winAtLevel == "Lv01-03")
        {
            SceneManager.LoadScene("Lv02-01");
        }
        else if (winAtLevel == "Lv02-01" || winAtLevel == "Lv02-02" || winAtLevel == "Lv02-03")
        {
            SceneManager.LoadScene("Lv03-01");
        }
        else if (winAtLevel == "Lv03-01" || winAtLevel == "Lv03-02" || winAtLevel == "Lv03-03")
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    public void Retry()
    {
        if (winAtLevel == "Lv01-01" || winAtLevel == "Lv01-02" || winAtLevel == "Lv01-03")
        {
            SceneManager.LoadScene("Lv01-01");
        }
        else if (winAtLevel == "Lv02-01" || winAtLevel == "Lv02-02" || winAtLevel == "Lv02-03")
        {
            SceneManager.LoadScene("Lv02-01");
        }
        else if (winAtLevel == "Lv03-01" || winAtLevel == "Lv03-02" || winAtLevel == "Lv03-03")
        {
            SceneManager.LoadScene("Lv03-01");
        }
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
