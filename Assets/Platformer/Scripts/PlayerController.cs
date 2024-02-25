using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, maxSpeed, minJumpForce, jumpBoost;

    public bool isGrounded;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.5f);

        // horizontal movement
        float moveX = Input.GetAxis("Horizontal");

        // running
        if (Input.GetKey(KeyCode.LeftShift))
        {
            maxSpeed = 14f;
            moveX *= 2f;
        }
        else
        {
            maxSpeed = 7f;
        }

        if(rb.velocity.x < maxSpeed && rb.velocity.x > maxSpeed * -1f)
        {
            rb.AddForce(Vector3.right * moveX * speed * Time.deltaTime, ForceMode.Force);
        }

        // slowdown
        if (isGrounded && moveX < 0.5f && moveX > -0.5f)
        {
            rb.drag = 5f;
        }
        else if (isGrounded && Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.drag = 1f;
        }
        else
        {
            rb.drag = 0f;
        }

        // jumping
        if(isGrounded && Input.GetKeyDown(KeyCode.Space)) 
        {
            rb.AddForce(Vector3.up * minJumpForce, ForceMode.Impulse);
        }

        // jump boost
        if (Input.GetKey(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.AddForce(Vector3.up * jumpBoost, ForceMode.Force);
        }
    }
}
