using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 20;  

 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ReceiveMissile(damage);
            }
        }
    }
}