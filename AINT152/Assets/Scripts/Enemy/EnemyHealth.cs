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
        Instantiate(healthDrop, transform.parent);
    }
}
