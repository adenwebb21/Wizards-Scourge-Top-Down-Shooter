using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;
    public Camera theCamera;
    public float smoothing = 5.0f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        theCamera = Camera.main;

        Vector3 mouse = theCamera.ScreenToWorldPoint(Input.mousePosition);

        rb.velocity = new Vector2(mouse.x, mouse.y) * speed;
    }

}
