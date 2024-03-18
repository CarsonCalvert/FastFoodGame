using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    public float speed = 15f;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        // Set the hand's speed
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        
        // Turn on collision detection between the hand and the player
        int playerLayer = LayerMask.NameToLayer("Player");
        Physics2D.IgnoreLayerCollision(gameObject.layer, playerLayer, false);
        player = GameObject.FindGameObjectWithTag("Player");
}

    // Update is called once per frame
    
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            Destroy(player);
            // Stop the game
            Time.timeScale = 0;
        }
    }
}