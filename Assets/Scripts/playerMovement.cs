using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //variables
    private float currentSpeed;
    
    public float walkingSpeed = 10f;
    public float runningSpeed = 15f;

    public float gravity = -0.5f;
    public float jumpSpeed = 1f;
    private float baseLineGravity;

    private float moveX;
    private float moveZ;
    private Vector3 move;
    
    public CharacterController characterController;
    void Start()
    {
        currentSpeed = walkingSpeed;
        baseLineGravity = gravity;
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        moveZ = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;

        move = transform.right * moveX +
                transform.up * gravity +
                transform.forward * moveZ;

        characterController.Move(move);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runningSpeed;
        }
        else 
        {
            currentSpeed = walkingSpeed;
        }

        if (characterController.isGrounded == true && Input.GetKey(KeyCode.Space))
        {
            gravity = baseLineGravity;
            gravity *= -jumpSpeed;
        }

        if(gravity > baseLineGravity) 
        {
            gravity -= 1.5f * Time.deltaTime;
        }
        
    }
}
