using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private string deathAtLevel;

    private void Start()
    {
        deathAtLevel = PlayerPrefs.GetString("DeathAtLevel");
        Debug.Log($"Game Over : {deathAtLevel}");
    }

    public void TryAgain()
    {
        if (deathAtLevel == "Lv01-01" || deathAtLevel == "Lv01-02" || deathAtLevel == "Lv01-03")
        {
            SceneManager.LoadScene("Lv01-01");
        }
        else if (deathAtLevel == "Lv02-01" || deathAtLevel == "Lv02-02" || deathAtLevel == "Lv02-03")
        {
            SceneManager.LoadScene("Lv02-01");
        }
        else if (deathAtLevel == "Lv03-01" || deathAtLevel == "Lv03-02" || deathAtLevel == "Lv03-03")
        {
            SceneManager.LoadScene("Lv03-01");
        }
    }


    public void BackMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
