using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public string sceneName { get; private set; }
    private PlayerHealth playerHealth;

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        Debug.Log($"Victory Address : {sceneName}");
        playerHealth = PlayerHealth.Instance;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("Victory Triggered");
            playerHealth.isWin = true;
            // playerHealth.ValidateWinLevel();
        }
    }
}
