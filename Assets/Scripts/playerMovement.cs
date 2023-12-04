using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;

public class playerMovement : MonoBehaviour
{
    #region variables
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float crawlSpeed = 1f;

    public Vector3 moveDirection;
    private Vector3 moveDirection2;
    private Vector3 moveDirectionX;
    private Vector3 moveDirectionZ;
    private Vector3 velocity;
    private float gravity = -30f;
    private float jumpheight = 2f;
    private float airSpeed = 0.78f;

    private float jumpAmount;
    private float jumpTimer = 0.5f;

    private CharacterController characterController;

    private float baseLineGravity;
    private float xMove;
    private float zMove;
    private Vector3 move;

    private GameObject Body;
    private float scaleChange;
    #endregion

    void Start()
    {
        characterController = GetComponent<CharacterController>(); //Gets CharacterController
    }

    void Update()
    {
        Move(); //Can Move
        jumpTimer += Time.deltaTime; //JumpTimer is = Time.DeltaTime
    }

    private void Move()
    {
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float MoveZ = Input.GetAxis("Vertical"); //Input MoveDirection Axis Z
        float MoveX = Input.GetAxis("Horizontal"); //Input MoveDirection Axis X

        moveDirectionZ = new Vector3(0, 0, MoveZ); //Axis Instellen In Vector3
        moveDirectionX = new Vector3(MoveX, 0, 0); //Axis Instellen In Vector3
        moveDirection = transform.TransformDirection(moveDirectionX + moveDirectionZ); //Transforms Move Directions

        if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) Walk(); //Walk If "LeftShift" Is Not Pressed
        else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)) Run();//Run If "LeftShift" Is Pressed

        if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftControl)) Walk(); //Walk If "LeftControl" Is Not Pressed
        else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftControl)) //Crawl If "LeftControl" Is Pressed
        {
            Crawl();
        }

        if (Input.GetKey(KeyCode.Space) && jumpTimer >= 0.5 && jumpAmount > 0) //Double Jump Part Of The Script
        {
            Jump();
            jumpAmount -= 1;
            jumpTimer = 0f;
        }

        if (characterController.isGrounded) //When Player Is Within StepOffset = Character Is Grounded
        {
            if (moveDirection != Vector3.zero)//Idle
            {
                Idle();
            }
            jumpAmount = 1; //Resets The Amount Of Possible Jumps 
        }
        else
        {
            moveDirection *= airSpeed;
        }
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime; // applies gravity
        characterController.Move(velocity * Time.deltaTime);
    }
    private void Walk() //The Walk Script
    {
        moveDirection *= walkSpeed;
    }
    private void Run() //The Run Script
    {
        moveDirection *= runSpeed;
    }
    private void Jump() //The Jump Script
    {
        velocity.y = Mathf.Sqrt(jumpheight * -2 * gravity);
    }
    private void Idle() //The Idle Script
    {

    }
    private void Crawl() //The Crawl Script
    {
        moveDirection *= crawlSpeed;
    }
}