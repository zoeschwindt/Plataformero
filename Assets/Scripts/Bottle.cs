using UnityEngine;

public class Bottle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ActivateDoubleJump();  // Activa un salto doble cada vez que se recoge una botella
                ScoreManager.instance.AddPoint(); // Suma un punto al puntaje
            }

            Destroy(gameObject);  // Destruye la botella
        }
    }
}


