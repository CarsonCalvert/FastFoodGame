using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    public float speed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        // Set the hand's speed
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }

   void OnCollisionEnter2D(Collision2D collision)
    {
    Debug.Log("OnCollisionEnter2D called");
    // Check if the hand collided with the player
    if (collision.gameObject.tag == "Player")
    {
        // Kill the player
        Destroy(collision.gameObject);
        // Stop the game
        Time.timeScale = 0;
    }
}
}