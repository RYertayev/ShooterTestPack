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
    public float jumpHeight;
    public Transform camera;
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
        // Получаем ввод от игрока
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Получаем направление взгляда камеры без учета вертикальной составляющей
        Vector3 cameraForward = camera.transform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();

        // Вычисляем направление движения
        Vector3 moveDirection = moveHorizontal * camera.transform.right + moveVertical * cameraForward;

        // Применяем скорость передвижения
        controller.Move(moveDirection * speed * Time.deltaTime);
    }
    void Jump()
    {
        bool isGrounded = Physics.CheckSphere(CheckGround.position, groundDistance, groundMask); //for check ground
        if (isGrounded && velocity.y < 0) //To fall if doesn't have ground
        {
            velocity.y = -7f;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime * 3f;
        }
        controller.Move(velocity * Time.deltaTime); //active gravitation

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
