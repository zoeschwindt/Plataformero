using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float gameTime = 60f;
    private float currentTime;

    public GameObject PanelPerdiste; // Panel de derrota
    public GameObject Victory;       // Panel de victoria
    public PlayerController playerController;
    public TextMeshProUGUI timerText;

    void Start()
    {
        currentTime = gameTime;
    }

    void Update()
    {
        // Si alguno de los paneles está activo, detener el tiempo
        if ((PanelPerdiste != null && PanelPerdiste.activeSelf) || (Victory != null && Victory.activeSelf))
        {
            return;
        }

        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            currentTime = 0;
            UpdateTimerUI();

            if (PanelPerdiste != null && !PanelPerdiste.activeSelf)
            {
                PanelPerdiste.SetActive(true);
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

