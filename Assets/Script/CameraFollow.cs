using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    public Transform target;          // El jugador

    [Header("Smoothness")]
    public float smoothSpeed = 5f;    // Entre 3 y 10 es ideal

    [Header("Offset")]
    public Vector3 offset = new Vector3(0, 1.5f, -10f);

    [Header("Vertical Follow")]
    public float yFollowStrength = 0.5f; 
    // 0 = no sigue en Y
    // 1 = sigue completamente en Y

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target == null) return;

        // Posición objetivo
        Vector3 desiredPos = target.position + offset;

        // Hacemos que la cámara siga la X completamente
        float x = desiredPos.x;

        // La Y la suavizamos para evitar movimientos bruscos
        float y = Mathf.Lerp(transform.position.y, desiredPos.y, yFollowStrength);

        // La Z siempre es la misma (2D)
        float z = desiredPos.z;

        Vector3 smoothPosition = new Vector3(x, y, z);

        // Movimiento suave final
        transform.position = Vector3.SmoothDamp(transform.position, smoothPosition, ref velocity, 1f / smoothSpeed);
    }
}
