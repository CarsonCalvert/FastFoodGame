using UnityEngine;

public class Animation : MonoBehaviour
{
    public Sprite idleSprite; // Drag your idle sprite here in the inspector
    public Sprite jumpingSprite; // Drag your jumping sprite here in the inspector
    public string terrainTag = "Untagged"; // The tag of your terrain

    private bool isOnTerrain; // Whether or not the player is on the terrain.
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get the Rigidbody2D, Animator and SpriteRenderer components
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

void Update()
{
    if (!isOnTerrain)
    {
        // If the character is not on the terrain, they are jumping
        // Change the sprite to the jumping sprite
        spriteRenderer.sprite = jumpingSprite;
    }
    else
    {
        // If the character is on the terrain, they are idle
        // Change the sprite back to the idle sprite
        spriteRenderer.sprite = idleSprite;
    }
}

    // This function is called when the character starts colliding with another object
    void OnCollisionEnter2D(Collision2D collision)
    {
        // If the character is colliding with the terrain, set isOnTerrain to true
        if (collision.gameObject.tag == terrainTag)
        {
            isOnTerrain = true;
        }
    }

    // This function is called when the character stops colliding with another object
    void OnCollisionExit2D(Collision2D collision)
    {
        // If the character is not colliding with the terrain, set isOnTerrain to false
        if (collision.gameObject.tag == terrainTag)
        {
            isOnTerrain = false;
        }
    }
}