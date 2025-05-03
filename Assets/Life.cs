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

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private PlayerController playerController;
    public void updateLife()
    {
        lifeUI.value = playerController.life;
    }


}
