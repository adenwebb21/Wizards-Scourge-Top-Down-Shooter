using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopDownCharacterController2D : MonoBehaviour {

    public float speed = 5.0f;
 
    Rigidbody2D rigidbody2D;

    public Transform player;

    public Text progress;

    float timer = 5;
    float decreaseValue = 0.2f;

    float maximumValue = 6;
    float currentValue = 0;
    float increaseValue = 0.5f;

    Vector3 moveBack = new Vector3(0, -0.5f);

    public Canvas qte;
    //Animator anim;

    //public Animator childAnim;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (qte.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentValue += increaseValue;
                progress.text = currentValue.ToString();
            }

            timer -= Time.deltaTime;

            if (currentValue == maximumValue)
            {
                qte.gameObject.SetActive(false);
                player.SetPositionAndRotation(moveBack, new Quaternion(0, 0, 0, 0));
                speed = 5.0f;
                currentValue = 0;
                //player.position.Set(player.position.x, player.position.y - 10, 0);
            }
        }

        
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //if(x == 0 && y == 0)
        //{
        //    anim.SetInteger("state", 0);
        //    childAnim.SetInteger("state", 0);
        //}
        //else
        //{
        //    childAnim.SetInteger("state", 1);
        //    anim.SetInteger("state", 1);
        //}

        rigidbody2D.velocity = new Vector2(x, y) * speed;
        rigidbody2D.angularVelocity = 0.0f;     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Pit")
        {
            speed = 0f;
            qte.gameObject.SetActive(true);
        }
    }


}
