using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 2f;             // Velocidad de movimiento
    public float jumpForce = 1.5f;             // Fuerza de salto

    [Header("Detección de suelo")]
    public Transform groundCheck;            // Punto para verificar el suelo
    public float groundCheckRadius = 0.2f;   // Radio de detección
    public LayerMask groundLayer;            // Capa del suelo

    private Rigidbody2D rb;                  // Referencia al Rigidbody2D
    private float move;                      // Input de movimiento
    private bool isGrounded;                 // Indica si está en el suelo

    void Start()
    {
        // Se obtiene el Rigidbody2D una sola vez
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Leer input de movimiento
        move = Input.GetAxisRaw("Horizontal");

        // Comprobar si está en el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Saltar
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Voltear sprite
        if (move > 0)
            transform.localScale = new Vector3(1, 1, 1); // Mirar derecha
        else if (move < 0)
            transform.localScale = new Vector3(-1, 1, 1); // Mirar izquierda
    }

    void FixedUpdate()
    {
        // Aplicar movimiento horizontal
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);
    }

    public bool GetIsGrounded()
    {
    return isGrounded;
    }
}