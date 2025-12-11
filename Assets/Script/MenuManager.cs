using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Cargar el primer nivel
    public void PlayGame()
    {
        SceneManager.LoadScene("playa"); // Cambia el nombre por el de tu nivel
    }

    // Salir del juego
    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
