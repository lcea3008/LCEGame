using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void Retry()
    {
        Time.timeScale = 1f; // Restaurar velocidad
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Restaurar velocidad
        SceneManager.LoadScene("MainMenu"); // Debe coincidir con tu escena
    }
}
