using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    #region variables
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float runSpeed = 5f;

    public Vector3 moveDirection;
    private Vector3 moveDirectionX;
    private Vector3 moveDirectionZ;
    private Vector3 velocity;
    private float gravity = -30f;
    private float jumpheight = 2f;
    private float airSpeed = 0.78f;

    private float jumpAmount;
    private float jumpTimer = 0.5f;

    public GameObject enemy1;
    public GameObject enemy2;
    public string win;

    public CharacterController characterController;
    #endregion

    void Start()
    {
        characterController = GetComponent<CharacterController>(); //Gets CharacterController
    }

    void Update()
    {
        Move(); //Can Move
        jumpTimer += Time.deltaTime; //JumpTimer is = Time.DeltaTime

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("home");
        }

    }

    private void Move()
    {
        // Count all game objects with the "NPC" tag
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");
        int npcCount = npcs.Length;

        // Check if the NPC count is zero
        if (npcCount == 0)
        {
            // Load the win scene
            SceneManager.LoadScene("win");
        }

        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float zMove = Input.GetAxis("Vertical"); //Input MoveDirection Axis Z
        float xMove = Input.GetAxis("Horizontal"); //Input MoveDirection Axis X

        moveDirectionZ = new Vector3(0, 0, zMove); //Axis Instellen In Vector3
        moveDirectionX = new Vector3(xMove, 0, 0); //Axis Instellen In Vector3
        moveDirection = transform.TransformDirection(moveDirectionX + moveDirectionZ); //Transforms Move Directions

        if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) Walk(); //Walk If "LeftShift" Is Not Pressed
        else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)) Run();//Run If "LeftShift" Is Pressed

        if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftControl)) Walk(); //Walk If "LeftControl" Is Not Pressed

        if (Input.GetKey(KeyCode.Space) && jumpTimer >= 0.5 && jumpAmount > 0) //Double Jump Part Of The Script
        {
            Jump();
            jumpAmount -= 1;
            jumpTimer = 0f;
        }

        if (characterController.isGrounded) //When Player Is Within StepOffset = Character Is Grounded
        {
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

  

}