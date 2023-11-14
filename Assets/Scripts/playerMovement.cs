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

    private float moveX;
    private float moveZ;
    private Vector3 move;
    
    public CharacterController characterController;
    void Start()
    {
        currentSpeed = walkingSpeed;
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
    }
}
