using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform player;       // El jugador a seguir
    public float parallaxFactor = 0.5f; // Qué tan rápido se mueve el fondo (0 = fijo, 1 = igual al jugador)

    private Vector3 startPos;

    void Start()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform; // Buscar al jugador por tag

        startPos = transform.position;
    }

    void Update()
    {
        // Movimiento del fondo proporcional al del jugador
        float distX = player.position.x * parallaxFactor;
        float distY = player.position.y * parallaxFactor * 0.5f; // opcional, menos movimiento vertical

        transform.position = new Vector3(startPos.x + distX, startPos.y + distY, transform.position.z);
    }
}
