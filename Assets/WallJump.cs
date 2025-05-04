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
        // Revisar si est� tocando una pared lateral
        bool touchingWallLeft = Physics.Raycast(transform.position, -transform.right, wallCheckDistance, wallLayer);
        bool touchingWallRight = Physics.Raycast(transform.position, transform.right, wallCheckDistance, wallLayer);
        bool isTouchingWall = touchingWallLeft || touchingWallRight;

        // Si est� tocando una pared, no est� en el piso, y est� cayendo...
        if (isTouchingWall && !playerController.inFloor && playerController.velocity.y < 0)
        {
            // Frena la ca�da (se queda "pegado")
            playerController.velocity.y = wallSlideSpeed;
        }
    }
}

