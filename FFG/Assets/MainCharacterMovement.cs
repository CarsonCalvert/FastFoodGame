using System.Collections;
using UnityEngine;

public class MainCharacterMovement : MonoBehaviour
{
    public float jumpForce = 5f;
    public float jumpSpeed = 2f;
    public bool isJumping = false;
    public Sprite jumpSprite;
    public Sprite normalSprite;
    public AudioClip jumpSound;
    public float animationStopTime = 1.5f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private float originalGravityScale;
    private Vector3 originalSpriteScale; // The original scale of the sprite

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on this gameobject");
        }

        if (animator == null)
        {
            Debug.LogError("Animator component not found on this gameobject");
        }

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on this gameobject");
        }

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on this gameobject");
        }
        //originalSpriteScale = spriteRenderer.transform.localScale;
        originalGravityScale = rb.gravityScale;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            animator.SetBool("isJumping", true);
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            rb.gravityScale = originalGravityScale / jumpSpeed;

            // Play the jump sound
            audioSource.PlayOneShot(jumpSound);
            //spriteRenderer.sprite = jumpSprite;
            //spriteRenderer.transform.localScale = jumpSpriteScale;
            // Stop the animations
            StartCoroutine(StopAnimations());
        }

        if (isJumping)
        {
            spriteRenderer.sprite = jumpSprite;
        }
    }

    IEnumerator StopAnimations()
    {
        // Stop the animations
        animator.enabled = false;

        // Wait for the specified time
        yield return new WaitForSeconds(animationStopTime);

        // Resume the animations
        animator.enabled = true;

        // Change the sprite back to the normal sprite
        //spriteRenderer.sprite = normalSprite;
        //spriteRenderer.transform.localScale = originalSpriteScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
        rb.gravityScale = originalGravityScale;
        animator.SetBool("isJumping", false);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Terrain")
        {
            Debug.Log("Collision ended with Terrain");
            audioSource.PlayOneShot(jumpSound);
            if (audioSource.isPlaying)
            {
                Debug.Log("AudioSource is playing");
            }
            else
            {
                Debug.Log("AudioSource is not playing");
            }
        }
    }

    public void onlanding()
    {
        animator.SetBool("isJumping", false);
    }
}