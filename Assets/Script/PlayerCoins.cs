using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerCoins : MonoBehaviour
{
    [Header("Monedas")]
    public int coins = 0;

    [Header("UI")]
    public TextMeshProUGUI coinsText;

    [Header("Victory Menu")]
    public GameObject victoryPanel;

    [Header("Sonido")]
    public AudioSource audioSource;   // <<--- Nuevo
    public AudioClip coinSound;       // <<--- Nuevo

    void Start()
    {
        UpdateCoinsUI();

        if (victoryPanel != null)
            victoryPanel.SetActive(false);
    }

    public void AddCoin(int amount)
    {
        coins += amount;
        UpdateCoinsUI();

        // 🔊 Reproducir sonido de moneda
        if (audioSource != null && coinSound != null)
            audioSource.PlayOneShot(coinSound);

        if (coins >= 6)
        {
            ShowVictoryMenu();
        }
    }

    void UpdateCoinsUI()
    {
        if (coinsText != null)
            coinsText.text = "Monedas: " + coins;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monedas"))
        {
            AddCoin(1);
            Destroy(collision.gameObject);
        }
    }

    void ShowVictoryMenu()
    {
        Time.timeScale = 0f;
        victoryPanel.SetActive(true);
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;

        string escenaActual = SceneManager.GetActiveScene().name;

        if (escenaActual == "playa")
        {
            SceneManager.LoadScene("desastre");
        }
        else if (escenaActual == "desastre")
        {
            SceneManager.LoadScene("postapocalipsis");
        }
    }

    public void GoToPostApocalisis()
    {   
        Time.timeScale = 1f;
        SceneManager.LoadScene("postapocalipsis");
    }


    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
