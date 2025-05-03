using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float gameTime = 60f;
    private float currentTime;

    public GameObject losePanel;
    public PlayerController playerController;
    public TextMeshProUGUI timerText; // Texto con TextMeshProUGUI

    void Start()
    {
        currentTime = gameTime;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            currentTime = 0;
            UpdateTimerUI();

            if (losePanel != null && !losePanel.activeSelf)
            {
                losePanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                if (playerController != null)
                    playerController.enabled = false;
            }
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

