using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAround : MonoBehaviour
{
    public float mouseSensitivity = 10f;
    public Transform playerBody;
    public float zLook;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        zLook = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, zLook);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
