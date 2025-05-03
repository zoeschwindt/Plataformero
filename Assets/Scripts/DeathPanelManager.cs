using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPanelManager : MonoBehaviour
{  
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void RestartGame()
    {
        // Volver a los valores originales (punto de inicio)
        PlayerPrefs.SetFloat("X", -33.59f);
        PlayerPrefs.SetFloat("Y", 2.544f);
        PlayerPrefs.SetFloat("Z", -16.22f);

        // Recargar la escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
