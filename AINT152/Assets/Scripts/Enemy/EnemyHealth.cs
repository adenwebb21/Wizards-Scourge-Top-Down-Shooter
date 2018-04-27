using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    private GameObject camera;
    private WaveController controller;
    public GameObject emitter;

    public GameObject healthDrop;

    public UnityEvent onTakeDamage;

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");

        controller = camera.GetComponent(typeof(WaveController)) as WaveController;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        onTakeDamage.Invoke();

        if (health <= 0)
        {
            GetComponent<AddScore>().DoSendScore();
            DropStuff();
            Destroy(transform.parent.gameObject);

            controller.ReduceEnemies();
        }       
    }

    void DropStuff()
    {
        if(Random.Range(0, 100) <= 50)
        {
            if(Random.Range(0, 100) <= 80)
            {
                Instantiate(healthDrop, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));               
            }
            else if(Random.Range(0, 100) <= 95)
            {
                for (int i = 0; i < Random.Range(1, 3); i++)
                {
                    Instantiate(healthDrop, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
                }
            }
            else
            {
                for (int i = 0; i < Random.Range(1, 4); i++)
                {
                    Instantiate(healthDrop, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
                }
            }
        }        
    }
}
