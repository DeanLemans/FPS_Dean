using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
public class weaponSway : MonoBehaviour
{
    [Header("Sway Settings")]
    [SerializeField] private float smooth;
    [SerializeField] private float multiplier;

    private void Update()
    {
        // get mouse input
        float xMouse = Input.GetAxisRaw("Mouse X") * multiplier;
        float yMouse = Input.GetAxisRaw("Mouse Y") * multiplier;

        // calculate target rotation
        Quaternion rotationX = Quaternion.AngleAxis(-yMouse, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(xMouse, Vector3.up);

        Quaternion targetRotation = rotationX * rotationY;

        // rotate 
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
    }
}
