using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // El objetivo a seguir (el jugador)         // Desplazamiento desde el objetivo

    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
