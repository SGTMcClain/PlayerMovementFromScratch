using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private float moveDirection;
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
    }
}
