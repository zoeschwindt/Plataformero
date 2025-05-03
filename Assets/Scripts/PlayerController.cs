using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    private float turnVelocity;
    private Vector3 velocity;
    private float gravity = -9.8f;
    private bool inFloor;

    public float doubleJumpHeightMultiplier = 1.5f;
    private int extraJumps;
    public int maxExtraJumps = 3; // Puedes aumentar este valor si deseas más saltos dobles.
    private bool canDoubleJump = false;

    public float speedMovement;
    public float turnTime = 0.2f;
    public float jumpHieght = 3;
    public float jumpForce = -2;
    public int life = 100;

    public Transform floor;
    public float floorDistance = 0.1f;
    public LayerMask layerFloor;
    [SerializeField] private Transform pointToSpawn;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    public void ActivateDoubleJump()
    {
        // Si el jugador no tiene saltos dobles disponibles, habilítalos.
        if (extraJumps < maxExtraJumps)
        {
            extraJumps++;  // Aumenta la cantidad de saltos dobles disponibles
        }
    }

    private void Update()
    {
        if (!controller.enabled) return;

        Walk();
        Jump();
        HandleDoubleJump();
        anim.SetFloat("velocityY", velocity.y);
    }

    private void Walk()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Z = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(X, 0, Z);

        if (direction != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
            float rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationAngle, ref turnVelocity, turnTime);
            Vector3 movementDirection = Quaternion.Euler(0, rotationAngle, 0) * Vector3.forward;
            transform.rotation = Quaternion.Euler(0, angle, 0);
            controller.Move(movementDirection.normalized * speedMovement * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    public void DisableJump()
    {
        anim.SetBool("isJumping", false);
    }

    private void Jump()
    {
        inFloor = Physics.CheckSphere(floor.position, floorDistance, layerFloor);
        anim.SetBool("inFloor", inFloor);
        if (inFloor && velocity.y < 0)
            velocity.y = jumpForce;
        if (Input.GetKeyDown(KeyCode.Space) && inFloor)
        {
            velocity.y = Mathf.Sqrt(jumpHieght * jumpForce * gravity);
            anim.SetBool("isJumping", true);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void HandleDoubleJump()
    {
        if (canDoubleJump && !inFloor && Input.GetKeyDown(KeyCode.X) && extraJumps > 0)
        {
            velocity.y = Mathf.Sqrt(jumpHieght * -2f * gravity) * doubleJumpHeightMultiplier;
            anim.SetTrigger("jump2");
            extraJumps--;  // Usar un salto doble disponible

            if (ScoreManager.instance.score > 0)
            {
                ScoreManager.instance.RemovePoint();
            }

            // Si no hay saltos dobles restantes, desactivar el flag de salto doble.
            if (extraJumps == 0)
            {
                canDoubleJump = false;
            }
        }

        if (inFloor)
        {
            // Cuando el jugador toca el suelo, puede usar los saltos dobles nuevamente si tiene
            // más botellas disponibles.
            canDoubleJump = true;
        }
    }
    public void Respawn()
    {
        controller.enabled = false;
        transform.position = pointToSpawn.position;
        controller.enabled = true;

    }
    public void ReceiveDamage()
    {
        life -= 50;
    }
    public void ReceiveMissile(int damage)
    {
        life -= damage;
    }
}
