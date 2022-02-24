using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //In Unity --> Edit --> Project Settings --> Input Manager --> Axes--> Jump, Horizontal, Vertical.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed); 

        //IsGrounded checks the sphere attached to player capsule is to the ground in order to avoid multiple jumps in air. 
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
        
    }
    
    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }
    
    bool IsGrounded()
    {
        //return true if ground sphere is true. The position of sphere is near to ground or floor
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
    
}
