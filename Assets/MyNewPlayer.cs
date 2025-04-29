using UnityEngine;
using UnityEngine.InputSystem;

public class MyNewPlayer : MonoBehaviour
{
    Vector2 moveInput;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveInput * Time.deltaTime);
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Jump!");
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log("Move: " + moveInput);
    }
    public void OnScreenShot(InputAction.CallbackContext context)
    {
    
        if (context.performed)
        {
            Debug.Log("ScreenShot!");
        }
    
    
    }

}
