using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    public void NextLevel()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        // Si estás en "playa" → vas a "desastre"
        if (currentScene == "playa")
        {
            SceneManager.LoadScene("desastre");
        }
        // Si estás en "desastre" → vas a "postapocalipsis"
        else if (currentScene == "desastre")
        {
            SceneManager.LoadScene("postapocalipsis");
        }
        else
        {
            Debug.LogWarning("No hay siguiente escena configurada para: " + currentScene);
        }
    }
    
    public void GoToApocalispsis()
    {
        SceneManager.LoadScene("postapocalisis");
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
