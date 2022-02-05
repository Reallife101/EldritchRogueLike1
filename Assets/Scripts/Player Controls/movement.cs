using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    public CharacterController controller;

    public float movementSpeed = 12.0f;
    public float gravity = -9.81f;
    public float jumpHeight = 3.0f;

    //Check ground variables
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool isSprinting;
    public bool isSliding;
    public bool isCrouching;
    public bool isGrounded;

    public Vector3 lastMove;

    private float currentSpeed;

    public Vector3 velocity;

    private void Start()
    {
        isCrouching = false;
        currentSpeed = movementSpeed;
        isSprinting = false;
        isSliding = false;
        lastMove = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

        // Get Movement Input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        handleCrouch();
        handleSpeed();

        // Move Character
        Vector3 move = transform.right * x + transform.forward * z;

        if (isSliding)
        {
            controller.Move(lastMove * currentSpeed * Time.deltaTime);
        } else
        {
            controller.Move(move * currentSpeed * Time.deltaTime);
            lastMove = move;
        }

        handleJump();

        // Gravity
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void handleJump()
    {
        //Grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void handleSpeed()
    {
        // Sprint
        if (isSliding)
        {
            currentSpeed = 2.5f * movementSpeed;
        }
        else if (isCrouching)
        {
            currentSpeed = 0.5f * movementSpeed;
        } else if (isSprinting)
        {
            currentSpeed = 2.0f * movementSpeed;
        } else
        {
            currentSpeed = movementSpeed;
        }
    }

    void handleCrouch()
    {
        isCrouching = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.C) ? true : false;

        if (isCrouching)
        {
            controller.height = 1f;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
            groundCheck.transform.position = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
        }
        else
        {
            controller.height = 2f;
            groundCheck.transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
        }
    }

}
