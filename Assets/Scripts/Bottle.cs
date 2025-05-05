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
                player.ActivateDoubleJump(); 
                ScoreManager.instance.AddPoint(); 
            }

            Destroy(gameObject);  
        }
    }
}


