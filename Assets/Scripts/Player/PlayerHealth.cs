using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : Singleton<PlayerHealth>
{
    public bool isDead { get; set; }
    public bool isWin { get; set; }
    public string sceneName { get; private set; }

    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float knockBackThrustAmount = 10f;
    [SerializeField] private float damageRecoveryTime = 1f;

    private Slider healthSlider;
    private Knockback knockback;
    private Flash flash;
    AudioManager audioManager;
    private int currentHealth;
    private bool canTakeDamage = true;

    const string HEALTH_SLIDER_TEXT = "Health Slider";
    readonly int DEATH_HASH = Animator.StringToHash("Death");
    private string pauseFeild;

    protected override void Awake()
    {
        base.Awake();

        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();
    }

    private void Start()
    {
        
        Debug.Log($"Player Address : {sceneName}");

        isDead = false;
        isWin = false;
        currentHealth = maxHealth;

        UpdateHealthSlider();
    }

    private void Update()
    {
        if (isWin == true) { ValidateWinLevel(); }
        sceneName = SceneManager.GetActiveScene().name;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        EnemyAI enemy = other.gameObject.GetComponent<EnemyAI>();

        if (enemy)
        {
            TakeDamage(1, other.transform);
        }
    }

    public void HealPlayer()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += 1;
            UpdateHealthSlider();
        }
    }

    public void TakeDamage(int damageAmount, Transform hitTransform)
    {
        if (!canTakeDamage) { return; }
        audioManager.PlaySFX(audioManager.hit02Sound, 0.6f);
        ScreenShakeManager.Instance.ShakeScreen();
        knockback.GetKnockedBack(hitTransform, knockBackThrustAmount);
        StartCoroutine(flash.FlashRoutine());
        canTakeDamage = false;
        currentHealth -= damageAmount;
        StartCoroutine(DamageRecoveryRoutine());
        UpdateHealthSlider();
        CheckIfPlayerDeath();
    }

    private void CheckIfPlayerDeath()
    {
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            Destroy(ActiveWeapon.Instance.gameObject);
            currentHealth = 0;
            GetComponent<Animator>().SetTrigger(DEATH_HASH);

            PlayerPrefs.SetString("DeathAtLevel", sceneName);
            StartCoroutine(DeathLoadSceneRoutine());
        }
    }

    private IEnumerator DeathLoadSceneRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        SceneManager.LoadScene("Game Over");
    }

    private void ValidateWinLevel()
    {
        isDead = true;
        if (ActiveWeapon.Instance != null)
        {
            Destroy(ActiveWeapon.Instance.gameObject);
        }
        currentHealth = 0;

        PlayerPrefs.SetString("WinAtLevel", sceneName);
        StartCoroutine(WinLoadSceneRoutine());
    }

    private IEnumerator WinLoadSceneRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        SceneManager.LoadScene("Win Level");
    }

    public void ResetPlayer()
    {
        if (this != null && !isDead)
        {
            isDead = true;
            if (ActiveWeapon.Instance != null)
            {
                Destroy(ActiveWeapon.Instance.gameObject);
            }

            currentHealth = 0;
            PlayerPrefs.SetString("PauseAtLevel", sceneName);
            pauseFeild = SceneManager.GetActiveScene().name;
            StartCoroutine(ResetPlayerRoutine());
        }
    }

    public IEnumerator ResetPlayerRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        if (this != null)
        {
            Destroy(gameObject);

            if (pauseFeild == "Lv01-01" || pauseFeild == "Lv01-02" || pauseFeild == "Lv01-03")
            {
                SceneManager.LoadScene("Lv01-01");
            }
            else if (pauseFeild == "Lv02-01" || pauseFeild == "Lv02-02" || pauseFeild == "Lv02-03")
            {
                SceneManager.LoadScene("Lv02-01");
            }
            else if (pauseFeild == "Lv03-01" || pauseFeild == "Lv03-02" || pauseFeild == "Lv03-03")
            {
                SceneManager.LoadScene("Lv03-01");
            }
        }
    }

    public void QuitSuddenly()
    {
        if (!isDead)
        {
            isDead = true;

            if (ActiveWeapon.Instance != null)
            {
                Destroy(ActiveWeapon.Instance.gameObject);
            }

            currentHealth = 0;
            PlayerPrefs.SetString("PauseAtLevel", sceneName);
            pauseFeild = SceneManager.GetActiveScene().name;

            if (this != null)
            {
                StartCoroutine(QuitSuddenlyRoutine());
            }
        }
    }


    public IEnumerator QuitSuddenlyRoutine()
    {
        yield return new WaitForSeconds(0.5f);

        if (this != null)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Main Menu");
        }
    }


    private IEnumerator DamageRecoveryRoutine()
    {
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
    }

    private void UpdateHealthSlider()
    {
        if (healthSlider == null)
        {
            healthSlider = GameObject.Find(HEALTH_SLIDER_TEXT).GetComponent<Slider>();
        }

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }
}
