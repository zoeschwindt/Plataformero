using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
   
    void Start()
    {
        Time.timeScale = 1;
    }

    
    void Update()
    {

    }
    public void MenuStart()
    {
        SceneManager.LoadScene("Nivel");
    }
    public void Salir()
    {
        Application.Quit();
    }
}
