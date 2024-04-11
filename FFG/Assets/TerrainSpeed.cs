using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpeed : MonoBehaviour
{
    private Animator _animator; // Reference to the Animator component
    public float initialSpeed = 50.0f; // The initial speed of the terrain
    public float speedIncreasePerSecond = 3f; // The amount to increase the speed by every second

    // Public property to get the animator speed
    public float AnimatorSpeed
    {
        get { return _animator.speed; }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get the Animator component
        _animator = GetComponent<Animator>();
        _animator.speed = initialSpeed; // Set the initial speed
    }

    // Update is called once per frame
    void Update()
    {
        // Increase the speed by speedIncreasePerSecond every second
        IncreaseSpeed(speedIncreasePerSecond * Time.deltaTime);
        Debug.Log("Current speed: " + _animator.speed);
    }

    // Public method to increase the speed
    public void IncreaseSpeed(float amount)
    {
        _animator.speed += amount;
    }
}