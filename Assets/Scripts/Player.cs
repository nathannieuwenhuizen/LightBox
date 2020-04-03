using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 5f;

    [SerializeField]
    private float jumpForce = 5f;

    private bool inAir = true;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * walkSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
    }

    public void Jump()
    {
        if (inAir) return;
        inAir = true;
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        inAir = false;
    }
}
