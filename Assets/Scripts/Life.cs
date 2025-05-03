using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public Slider lifeUI;
    private PlayerController PlayerController;
    public static Life Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        if(PlayerPrefs.GetFloat("X") == 0 && PlayerPrefs.GetFloat("Y") == 0 && PlayerPrefs.GetFloat("Z") == 0)
        {
            PlayerPrefs.SetFloat("X", -33.59f);
            PlayerPrefs.SetFloat("Y", 2.544f);
            PlayerPrefs.SetFloat("Z", -16.22f);
        }

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private PlayerController playerController;
    public void updateLife()
    {
        lifeUI.value = playerController.life;
    }


}
