using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterMovement : MonoBehaviour
{
    public float jumpForce = 5f;
    public float jumpSpeed = 2f;
    private bool isJumping = false;
    private Rigidbody2D rb;
    private float originalGravityScale; // To store the original gravity scale
    private Animator animator; // Animator component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Get the Animator component
        originalGravityScale = rb.gravityScale; // Store the original gravity scale

        // Add this line to check if the animator component is null
        if (animator == null)
        {
            Debug.LogError("Animator component not found on this gameobject");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update method called");

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            Debug.Log("Jump button pressed and character is not already jumping");
            isJumping = true;
            animator.SetBool("isJumping", true); // Set the jumping parameter to true when the character starts jumping
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            rb.gravityScale = originalGravityScale / jumpSpeed; // Adjust the gravity scale based on the jump speed
        }
    }

    // This function is called when the character lands after jumping
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
        isJumping = false;
        rb.gravityScale = originalGravityScale; // Reset the gravity scale when the character lands
        animator.SetBool("isJumping", false); // Set the jumping parameter to false when the character lands
    }

    public void onlanding()
    {
        Debug.Log("onlanding method called");
        animator.SetBool("isJumping", false); // Set the jumping parameter to false when the character lands
    }
}