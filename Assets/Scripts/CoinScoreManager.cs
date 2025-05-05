using TMPro;
using UnityEngine;

public class CoinScoreManager : MonoBehaviour
{
    public static CoinScoreManager instance;  

    public int coinScore = 0;  
    public TMP_Text coinScoreText;  

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

   
    public void AddCoinPoint()
    {
        coinScore++;  
        coinScoreText.text = "" + coinScore.ToString(); 
    }

}
