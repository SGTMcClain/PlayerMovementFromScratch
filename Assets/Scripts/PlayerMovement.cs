using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private float moveDirection;

    public float jumpForce = 5f;
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get user Input
        moveDirection = Input.GetAxis("Horizontal");

        // Apply Movement to Rigidibody2D
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        // Check if the jump button was pressed
        if(Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        //Check if the jump button was released
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

        // If the player is jumping then apply jump force to the Player
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        
    }
}
