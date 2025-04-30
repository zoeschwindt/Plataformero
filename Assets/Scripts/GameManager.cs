using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public static GameManager Instance;
    //public static bool gameOver;
    //public GameObject defeatScreen;

    //[SerializeField] private AudioSource audioSource;
    //[SerializeField] private AudioClip audioClipGamePlay;
    //[SerializeField] private AudioClip audioClipGameOver;

    //private void Awake()
    //{
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }

    //    audioSource.clip = audioClipGamePlay;
    //}
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    //void Start()
    //{
    //    gameOver = false;
    //    defeatScreen.SetActive(false);
    //    audioSource.Play();

    //    // Bloquear y ocultar el cursor al inicio
    //    Cursor.lockState = CursorLockMode.Locked;
    //    Cursor.visible = false;
    //}

    //void Update()
    //{
    //    if (gameOver)
    //    {
    //        Time.timeScale = 0f;
    //    }
    //}

    //public void DefeatScreen()
    //{
    //    defeatScreen.SetActive(true);
    //    audioSource.clip = audioClipGameOver;
    //    audioSource.Play();

    //    Cursor.lockState = CursorLockMode.Confined;
    //    Cursor.visible = true;
    //}

    //public void ResetGame()
    //{
    //    audioSource.clip = audioClipGamePlay;
    //    audioSource.Play();
    //}
}