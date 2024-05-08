using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity;
    public float xRotate = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        xRotate = xRotate - mouseY;
        xRotate = Mathf.Clamp(xRotate, -30, 30);
        transform.localRotation = Quaternion.Euler(xRotate, 0, 0);
        player.Rotate(Vector3.up * mouseX); 
    }
}
