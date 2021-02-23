using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{


    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float sprintSpeed = 17f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Vector3 old_pos;
    public cameraBobScript camblob;


    Vector3 velocity;
    bool isGrounded;
    float basespeed;
    // Start is called before the first frame update
    void Start()
    {
        basespeed = speed;
        old_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
            camblob.bobFrequency = sprintSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            speed = basespeed;
            camblob.bobFrequency = basespeed;
        }



        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed *Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity* Time.deltaTime);

        if (transform.position != old_pos)
        {
            camblob.isWalking = true;
        }
        else {
            camblob.isWalking = false;
        }
        old_pos = transform.position;
    }


}
