using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2;
    public float horizontalSpeed = 3;
    public float jumpForce = 20f;
    public float rightLimit = 6.5f;
    public float leftLimit = -6.5f;
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    public float mouseSensitivity = 100f;

    private Rigidbody rb;
    private bool isGrounded;
    private float rotationY = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

       
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
       
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.Self);

        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > leftLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed, Space.Self);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < rightLimit)
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed, Space.Self);
            }
        }

       
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

      
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        rotationY += mouseX;
        transform.localRotation = Quaternion.Euler(0f, rotationY, 0f);
    }
}
