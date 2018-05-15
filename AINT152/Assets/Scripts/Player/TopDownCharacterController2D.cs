using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController2D : MonoBehaviour {

    public float speed = 5.0f;
    private float originalSpeed = 5.0f;


    Rigidbody2D rigidbody2D;
    Animator anim;

    public Animator childAnim;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (x == 0 && y == 0)
        {
            anim.SetInteger("state", 0);
            childAnim.SetInteger("state", 0);
        }
        else
        {
            childAnim.SetInteger("state", 1);
            anim.SetInteger("state", 1);
        }

        rigidbody2D.velocity = new Vector2(x, y) * speed;
        rigidbody2D.angularVelocity = 0.0f;   
    }
}
