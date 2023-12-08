using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class weaponSway : MonoBehaviour
{
    [Header("Sway Things")]
    [SerializeField] private float movementSwayAmount = 0.1f;
    [SerializeField] private float jumpSwayAmount = 0.2f;
    [SerializeField] private float smooth;

    private playerMovement playerMovementScript;
    private Vector3 startPosition;
    private float xMouse;
    private float yMouse;

    private void Start()
    {
        playerMovementScript = GetComponentInParent<playerMovement>(); //playerMovement script is attached to the parent object
        startPosition = transform.localPosition;
    }

    private void Update()
    {

        // Calculate rotation from mouse input
        Quaternion rotationX = Quaternion.AngleAxis(-yMouse, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(xMouse, Vector3.up);
        Quaternion targetRotation = rotationX * rotationY;

        //Apply rotation from mouse input
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);

        // Calculate movement sway based on player movement
        Vector3 movementSway = new Vector3
            (
            playerMovementScript.moveDirection.x * movementSwayAmount,
            playerMovementScript.characterController.isGrounded ? 0 : jumpSwayAmount, // Only apply jump sway if the player is not grounded
            playerMovementScript.moveDirection.z * movementSwayAmount
            );

        // Apply movement sway
        transform.localPosition = startPosition + movementSway; // Add sway to the initial position
    }
}
