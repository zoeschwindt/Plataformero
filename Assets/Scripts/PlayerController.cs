using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    private float turnVelocity;
    private Vector3 velocity;
    private float gravity = -9.8f;
    private bool inFloor;

    public float speedMovement;
    public float turnTime = 0.2f;
    public float jumpHieght = 3;
    public float jumpForce = -2;

    public Transform floor;
    public float floorDistance = 0.1f;
    public LayerMask layerFloor;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Walk();
        Jump();
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
            anim.SetBool("isMoving", false);
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

}



