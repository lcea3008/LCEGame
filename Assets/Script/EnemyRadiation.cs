using UnityEngine;

public class EnemyRadiation : MonoBehaviour
{
    [Header("Radiación")]
    public float radiationRadius = 2f; // Radio donde el jugador empieza a recibir daño
    public int radiationDamage = 1;    // Daño por tick
    public float damageInterval = 1f;  // Tiempo entre daños (1 = daño por segundo)

    private float damageTimer = 0f;

    private Transform player;

    void Start()
    {
        // Buscar al jugador por tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= radiationRadius)
        {
            damageTimer += Time.deltaTime;

            if (damageTimer >= damageInterval)
            {
                ApplyRadiationDamage();
                damageTimer = 0f;
            }
        }
        else
        {
            // Si el jugador sale del área, reiniciamos el contador
            damageTimer = damageInterval;
        }
    }

    void ApplyRadiationDamage()
    {
        PlayerHealth ph = player.GetComponent<PlayerHealth>();

        if (ph != null)
        {
            ph.TakeDamage(radiationDamage);
            Debug.Log("El jugador recibe daño por radiación.");
        }
    }

    void OnDrawGizmosSelected()
    {
        // Para visualizar el radio en la escena
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radiationRadius);
    }
}
