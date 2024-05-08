using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed;
    public CharacterController controller;
    public float gravity = -9.8f;
    public LayerMask groundMask;
    public float groundDistance = 0.2f;
    public Transform CheckGround;
    Vector3 velocity;
    public float jumpHeight = 1f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }
   
    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * speed * Time.deltaTime);
    }
    void Jump()
    {
        bool isGrounded = Physics.CheckSphere(CheckGround.position, groundDistance, groundMask); //for check ground
        if (isGrounded && velocity.y < 0) //To fall if doesn't have ground
        {
            velocity.y = -2f;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
        controller.Move(velocity * Time.deltaTime); //active gravitation

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
