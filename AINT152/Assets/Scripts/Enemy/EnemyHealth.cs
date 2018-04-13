using UnityEngine;
using System.Collections;
public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    private GameObject camera;
    private WaveController controller;

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");

        controller = camera.GetComponent(typeof(WaveController)) as WaveController;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            GetComponent<AddScore>().DoSendScore();
            Destroy(transform.parent.gameObject);

            controller.ReduceEnemies();
        }
    }
}
