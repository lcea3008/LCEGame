using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cam;              // Cámara
    public float parallaxSpeed = 0.5f; // 0 = fijo / 1 = se mueve igual que la cámara

    private float length;    // Ancho del sprite
    private float startPos;  // Posición inicial del sprite

    void Start()
    {
        startPos = transform.position.x;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null)
            sr = GetComponentInChildren<SpriteRenderer>();

        length = sr.bounds.size.x;
    }

    void Update()
    {
        // Movimiento parallax
        float dist = cam.position.x * parallaxSpeed;
        float temp = cam.position.x * (1 - parallaxSpeed);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        // Scroll infinito
        if (temp > startPos + length)
        {
            startPos += length;
        }
        else if (temp < startPos - length)
        {
            startPos -= length;
        }
    }
}
