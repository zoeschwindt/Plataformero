using UnityEngine;

public class Coinn : MonoBehaviour
{

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  
        {
          
            CoinScoreManager.instance.AddCoinPoint();

            
            Destroy(gameObject);
        }
    }
}
