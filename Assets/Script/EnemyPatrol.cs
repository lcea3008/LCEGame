using UnityEngine;

public class EnemyPatrolActivable : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Transform target;
    private Animator animator;
    private bool isActive = false; // ENEMIGO INACTIVO HASTA VER AL PLAYER

    void Start()
    {
        target = pointB;
        animator = GetComponent<Animator>();

        // No activar animación todavía
        animator.SetBool("Run", false);
    }

    void Update()
    {
        if (!isActive) return; // ❗ Si no está activo, no se mueve

        // Movimiento
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Cambiar de dirección
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            target = (target == pointA) ? pointB : pointA;
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // Cuando el jugador entra al rango
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isActive = true;
            animator.SetBool("Run", true);
        }
    }

    // Si quieres que deje de patrullar cuando el jugador salga, activa esto:
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isActive = false;
            animator.SetBool("Run", false);
        }
    }
}
