using UnityEngine;

public class LevelMenu : MonoBehaviour
{
    public GameObject panelNiveles;

    public void AbrirMenuNiveles()
    {
        panelNiveles.SetActive(true);
    }

    public void CerrarMenuNiveles()
    {
        panelNiveles.SetActive(false);
    }
}
