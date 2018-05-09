using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDropMovement : MonoBehaviour {

    public float speed = 5000f;

    private PlayerHealth health;

    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * speed);     // The health drops are created with a random direction, they are accelerated here
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().drag += 1;      // and almost immediately slowed to a stop
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        health = collision.gameObject.GetComponent<PlayerHealth>();

        if (collision.gameObject.tag == "Pit" || collision.gameObject.tag == "Wall")        // Stop health drop movement on collision with a wall or a hole
        {
            GetComponent<Rigidbody2D>().drag += 50;
        }

        if (collision.gameObject.tag == "Player" && health.health != health.maxHealth)      // Remove health drop on collision with player
        {
            collision.gameObject.SendMessage("HealthPotion", 10);
            Destroy(gameObject);
        }
    }
}
