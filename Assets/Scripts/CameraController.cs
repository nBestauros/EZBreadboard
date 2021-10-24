using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSensitivity = 90;
    public float climbSpeed = 4;
    public float normalMoveSpeed = 10;
    public float slowMoveFactor = 0.25f;

    private float rotationX = 0;
    private float rotationY = 0;
    void Update()
    {
        // Collects rotation data from the mouse on the x and y axis
        rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime; 
        rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, -90, 90);

        transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

        if (Input.GetKey(KeyCode.LeftControl)) // if left control is held down, move at a slower pace
        {
            transform.position += transform.forward * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
            transform.position += transform.right * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
        } 
        else // move at the normal speed
        {
            transform.position += transform.forward * normalMoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
            transform.position += transform.right * normalMoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.E)) // Press E to move upwards
        {
            transform.position += transform.up * climbSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Q)) // Press Q to move downwards
        {
            transform.position -= transform.up * climbSpeed * Time.deltaTime;
        }
    }
}
