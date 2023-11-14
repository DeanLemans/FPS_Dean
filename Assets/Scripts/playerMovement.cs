using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //variables
    [SerializeField]
    private float currentSpeed;
    
    public float walkingSpeed = 10f;
    public float runningSpeed = 15f;

    private float moveX;
    private float moveZ;
    
    public CharacterController characterController;
    void Start()
    {
        currentSpeed = walkingSpeed;
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        moveZ = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;
    }
}
