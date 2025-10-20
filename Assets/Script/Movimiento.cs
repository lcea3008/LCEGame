using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Animator animator;
    private float move;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimiento
        move = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(move));

        // Salto
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("Jump");
        }

        // Ataque
        if (Input.GetMouseButtonDown(0)) // clic izquierdo
        {
            animator.SetTrigger("Ataque");
        }

        // Apuntar (se activa con F, solo una vez)
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Apuntar");
        }
    }
}
