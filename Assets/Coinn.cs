using UnityEngine;

public class Coinn : MonoBehaviour
{

    // Evento que se ejecuta cuando el jugador recoge la moneda
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Si el jugador toca la moneda
        {
            // Sumar un punto al CoinScoreManager
            CoinScoreManager.instance.AddCoinPoint();

            // Destruir la moneda después de que el jugador la recoge
            Destroy(gameObject);
        }
    }
}
