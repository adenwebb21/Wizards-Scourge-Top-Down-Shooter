using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDropMovement : MonoBehaviour {

    public float speed = 5000f;

    private PlayerHealth health;

    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().drag += 1;
    }

    //private void OnTriggerEnter(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Pit" || collision.gameObject.tag == "Wall")
    //    {
    //        GetComponent<Rigidbody2D>().drag += 50;
    //    }

    //    if (collision.gameObject.tag == "Player")
    //    {
    //        collision.gameObject.SendMessage("HealthPotion", 5);
    //        Destroy(gameObject);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        health = collision.gameObject.GetComponent<PlayerHealth>();

        if (collision.gameObject.tag == "Pit" || collision.gameObject.tag == "Wall")
        {
            GetComponent<Rigidbody2D>().drag += 50;
        }

        if (collision.gameObject.tag == "Player" && health.health != health.maxHealth)
        {
            collision.gameObject.SendMessage("HealthPotion", 10);
            Destroy(gameObject);
        }
    }
}
