using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpSpeed = 10;
    private bool TouchingGround;
    private Animator anim;

    private int wireCount;

    void Start()
    {
        // Declare variables
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // If clicks both claws together at the same time, restart game
        if (Input.GetKey("space") == true && Input.GetKey(KeyCode.Z) == true)
        {
            GameControl.instance.RestartGame();
        }
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }

    void PlayerJump()
    {
        // If player presses space/clicks claw and is on the ground, player jumps and changes sprite
        if (Input.GetKey("space") == true && TouchingGround == true)
        {
            rb.AddForce(Vector2.up * jumpSpeed);
            anim.SetBool("Snip", true);
        }
    }

    // If player is touching ground, set bool to true
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            TouchingGround = true;
            anim.SetBool("Snip", false);
        }
    }

    // If player is not touching ground, set bool to false
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            TouchingGround = false;
        }
    }
}
