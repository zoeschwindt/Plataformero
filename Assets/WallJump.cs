using Unity.VisualScripting;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    public LayerMask wallLayer;
    public float wallCheckDistance = 0.5f;
    public float wallSlideSpeed = -1f;

    private CharacterController controller;
    private PlayerController playerController;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerController = GetComponent<PlayerController>();
    }
    
    void Update()
    {
        
        bool isTouchingWall = Physics.CheckSphere(transform.position, wallCheckDistance, wallLayer);

        // Si está tocando una pared, no está en el piso, y está cayendo...
        if (isTouchingWall && !playerController.inFloor )
        {
            // Frena la caída (se queda "pegado")
            playerController.velocity.y = wallSlideSpeed;
        }
    }
}

