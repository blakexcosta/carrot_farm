using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12; // spped
    Vector3 velocity; //for gravity calculations
    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    public Transform groundCheck; // ground check object transform
    public float groundDistance = 0.4f; //sphere distance ground should check
    public LayerMask groundMask; // objects should check for
    bool isGrounded; //private variable to check if grounded

   
    // jump velocity is v = sqrt(jumpheight-2*gravity)
    // Update is called once per frame
    void Update()
    {
        //project invisible sphere to prevent velocity build-up and see if object on ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0) //resets velocity accordingly so long as object is grounded and 
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //arrow in direction want to move
        Vector3 move = transform.right * x + transform.forward * z; //direction want to move

        //move object by speed and delta time to account for frame descrepancies
        controller.Move(move * speed * Time.deltaTime);

        //calculate jumping, mapped to spacebar
        if(Input.GetButton("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //gravity calculation
        velocity.y += gravity * Time.deltaTime; //calculating gravity/velocity
        controller.Move(velocity * Time.deltaTime); //multiply by deltatime again to get the squaring effect of delta Y = 1/2((g) * (t**2)) 
    }
}
