using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Vida")]
    [SerializeField] private int maxHealth = 20;
    [SerializeField] private int currentHealth;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI healthValueInside;

    [Header("Game Over UI")]
    public GameObject gameOverPanel;

    [Header("Sonido")]
    public AudioSource audioSource;      // <<--- Nuevo
    public AudioClip damageSound;        // <<--- Nuevo

    public Action<int, int> OnHealthChanged;
    public Action OnDeath;

    private bool isDead = false;

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;

    void Start()
    {
        if (maxHealth < 1) maxHealth = 1;

        currentHealth = Mathf.Clamp(currentHealth > 0 ? currentHealth : maxHealth, 0, maxHealth);
        isDead = currentHealth == 0;

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        UpdateHealthUI();
    }

    // Daño al jugador
    public void TakeDamage(int damage)
    {
        if (isDead) return;
        if (damage <= 0) return;

        // 🔊 Reproducir sonido de daño
        if (audioSource != null && damageSound != null)
            audioSource.PlayOneShot(damageSound);

        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        UpdateHealthUI();

        if (currentHealth == 0 && !isDead)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (isDead) return;
        if (amount <= 0) return;

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UpdateHealthUI();
    }

    public void SetHealth(int value)
    {
        if (isDead) return;

        currentHealth = Mathf.Clamp(value, 0, maxHealth);
        UpdateHealthUI();

        if (currentHealth == 0 && !isDead)
            Die();
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
            healthText.text = "Vida: " + currentHealth;

        if (healthBar != null)
        {
            healthBar.value = currentHealth;

            if (healthBar.fillRect != null)
            {
                Image fill = healthBar.fillRect.GetComponent<Image>();

                if (fill != null)
                {
                    float percent = (float)currentHealth / maxHealth;

                    if (percent > 0.6f) fill.color = Color.green;
                    else if (percent > 0.3f) fill.color = Color.yellow;
                    else fill.color = Color.red;
                }
            }
        }

        if (healthValueInside != null)
            healthValueInside.text = currentHealth + " / " + maxHealth;

        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    void OnValidate()
    {
        if (maxHealth < 1) maxHealth = 1;
        currentHealth = Mathf.Clamp(currentHealth > 0 ? currentHealth : maxHealth, 0, maxHealth);

        if (healthText != null)
            healthText.text = "Vida: " + currentHealth;

        if (healthValueInside != null)
            healthValueInside.text = currentHealth + " / " + maxHealth;
    }

    // Sistema Game Over
    void Die()
    {
        isDead = true;
        Debug.Log("El jugador murió");
        OnDeath?.Invoke();

        Time.timeScale = 0f;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }
}
