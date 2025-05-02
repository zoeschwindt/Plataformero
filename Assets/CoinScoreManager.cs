using TMPro;
using UnityEngine;

public class CoinScoreManager : MonoBehaviour
{
    public static CoinScoreManager instance;  // Instancia para acceso global

    public int coinScore = 0;  // Puntaje de las monedas
    public TMP_Text coinScoreText;  // Para mostrar el puntaje de las monedas en pantalla

    private void Awake()
    {
        // Asegura que solo haya una instancia (singleton)
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);  // Si ya existe una instancia, destrúyela
        }
    }

    // Método para agregar puntos por monedas
    public void AddCoinPoint()
    {
        coinScore++;  // Aumenta el puntaje por moneda
        coinScoreText.text = "" + coinScore.ToString();  // Actualiza la UI
    }

}
