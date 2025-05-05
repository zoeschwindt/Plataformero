using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public TMP_Text scoreText;  

    private void Awake()
    {
       
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
            scoreText.text = score.ToString();
        }
    }
    public void AddPoint()
    {
        score++;
        scoreText.text = score.ToString();
    }
}