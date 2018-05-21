using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;    
    public int attackDamage = 10;               
                
    GameObject player;                  
    PlayerHealth playerHealth;
    public Animator enemyAnimator;

    Collider2D collision;
    
    public bool playerInRange;                   
    float timer;
    bool isSwordInStartingPos = false;      // This is used to determine which version of the animation should be played

    private int animationAttackState;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        collision = other;

        if (other.gameObject == player)
        {
            playerInRange = true;
            enemyAnimator.SetBool("isAttacking", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
            enemyAnimator.SetBool("isAttacking", false);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange)
        {
            Attack();
        }
    }

    void Attack()
    {
        timer = 0f;

        animationAttackState = enemyAnimator.GetInteger("attackoption");

        if(isSwordInStartingPos)        // Swaps back and forth between animations
        {
            enemyAnimator.SetInteger("attackoption", 1);
        }
        else if(!isSwordInStartingPos)
        {
            enemyAnimator.SetInteger("attackoption", 2);
        }

        isSwordInStartingPos = !isSwordInStartingPos;       // Invert

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("TakeDamage", attackDamage);
        }
    }
}
