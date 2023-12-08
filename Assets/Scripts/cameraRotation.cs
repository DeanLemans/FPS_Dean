using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class cameraRotation : MonoBehaviour
{
    
    public Transform player;
    private float xMouse;
    private float yMouse;
    private float xRotation; 
    private float yRotation;
    public float speed = 1500f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        xMouse = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        yMouse = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;

        xRotation -= yMouse;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * xMouse);
    }
    
}
