using UnityEngine;
using UnityEngine.Video;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    private float turnVelocity;
    [HideInInspector] public Vector3 velocity;
    private float gravity = -9.8f;
    [HideInInspector] public bool inFloor;

    public float doubleJumpHeightMultiplier = 1.5f;
    private int extraJumps;
    public int maxExtraJumps = 3; 
    private bool canDoubleJump = false;

    public LayerMask wallLayer;
    public bool isWallGrip;

    public GameObject losePanel;
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
        transform.position = new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), PlayerPrefs.GetFloat("Z"));


        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    public void ActivateDoubleJump()
    {
       
        if (extraJumps < maxExtraJumps)
        {
            extraJumps++;  
        }
    }

    private void Update()
    {
        if (!controller.enabled) return;
        WallGrip();
        Walk();
        Jump();
        HandleDoubleJump();
        anim.SetFloat("velocityY", velocity.y);
        Die();
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
        if (!isWallGrip)
        {
            velocity.y += gravity * Time.deltaTime;

        }
        controller.Move(velocity * Time.deltaTime);
    }

    private void WallGrip()
    {
        if (Physics.CheckSphere(transform.position, 0.5f, wallLayer))
        {
            isWallGrip = true;
        }
        else
        {
            isWallGrip = false;
        }
    }
    private void HandleDoubleJump()
    {
        if (canDoubleJump && !inFloor && Input.GetKeyDown(KeyCode.X) && extraJumps > 0)
        {
            velocity.y = Mathf.Sqrt(jumpHieght * -2f * gravity) * doubleJumpHeightMultiplier;
            anim.SetTrigger("jump2");
            extraJumps--; 

            if (ScoreManager.instance.score > 0)
            {
                ScoreManager.instance.RemovePoint();
            }

          
            if (extraJumps == 0)
            {
                canDoubleJump = false;
            }
        }

        if (inFloor)
        {
          
     
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
        Life.Instance.updateLife();
    }
    public void ReceiveMissile(int damage)
    {
        life -= damage;
        Life.Instance.updateLife();

        
        if (life > 0)
        {
            Respawn();
        }
    }
    private void Die()
    {
        if (life <= 0)
        {
            gameObject.SetActive(false); 
            if (losePanel != null)
            {
                losePanel.SetActive(true); 
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
