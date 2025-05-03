using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 20;  // Daño que hace este enemigo

    // Cambiado de OnCollisionEnter a OnTriggerEnter
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ReceiveMissile(damage);  // Llama a ReceiveMissile con el daño de este enemigo
            }
        }
    }
}