using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject panelPause;
    public bool isPaused = false;

    public void TogglePause()
    {
        if (!isPaused)
            PauseGame();
        else
            ResumeGame();
    }

    public void PauseGame()
    {
        panelPause.SetActive(true);
        Time.timeScale = 0f;  
        isPaused = true;
    }

    public void ResumeGame()
    {
        panelPause.SetActive(false);
        Time.timeScale = 1f; 
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;     // Restaurar por si estaba en pausa
        SceneManager.LoadScene("MainMenu");  // Asegúrate que el nombre coincide EXACTO
    }
}
