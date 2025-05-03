using UnityEngine;
using UnityEngine.Events;

public class DetectionArea : MonoBehaviour
{
    private PlayerController playerController;
    public UnityEvent detectionEvent;


    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            detectionEvent.Invoke();
        }
    }
    public void Respawn(Transform pointToSpawn)
    {
        playerController.transform.position = pointToSpawn.position;
    }
}
