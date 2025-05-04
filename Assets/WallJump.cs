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
        // Revisar si está tocando una pared lateral
        bool touchingWallLeft = Physics.Raycast(transform.position, -transform.right, wallCheckDistance, wallLayer);
        bool touchingWallRight = Physics.Raycast(transform.position, transform.right, wallCheckDistance, wallLayer);
        bool isTouchingWall = touchingWallLeft || touchingWallRight;

        // Si está tocando una pared, no está en el piso, y está cayendo...
        if (isTouchingWall && !playerController.inFloor && playerController.velocity.y < 0)
        {
            // Frena la caída (se queda "pegado")
            playerController.velocity.y = wallSlideSpeed;
        }
    }
}

