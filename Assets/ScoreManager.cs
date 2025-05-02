using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public TMP_Text scoreText;  // Ahora compatible con TextMeshPro

    private void Awake()
    {
        // Asegura que haya una sola instancia (singleton)
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void RemovePoint()
    {
        if (score > 0)
        {
            score--;
            scoreText.text = "" + score.ToString();
        }
    }
    public void AddPoint()
    {
        score++;
        scoreText.text = "" + score.ToString();
    }
}