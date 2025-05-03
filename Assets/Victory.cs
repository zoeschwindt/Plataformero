using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameObject victoryPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            victoryPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
                player.enabled = false;
        }
    }
}
