using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 2; // cantidad de vida que cura

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth ph = collision.GetComponent<PlayerHealth>();

            if (ph != null)
            {
                ph.Heal(healAmount);
            }

            Destroy(gameObject); // destruir el objeto al recogerlo
        }
    }
}
