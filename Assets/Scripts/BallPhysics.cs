using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    Rigidbody2D rigidBody2d;
    private Vector2 destination;

    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Assuming you want to set the velocity of the rigidbody towards the destination
        rigidBody2d.velocity = destination.normalized * 3; // normalize the vector to maintain constant speed
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 otherPos = other.transform.position;
        destination = (Vector2)transform.position - otherPos;
        Debug.Log("COLLISION: " + otherPos);
    }
}