using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{

    public float speed;
    public float lineOfSite;
    public GameObject player1;
    public GameObject player2;

    public int health = 5;
    public GameObject deathEffect;
    public GameObject explosion;


    private void Start()
    {


        
    }


    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player1.transform.position, transform.position);
        float distanceFromPlayer2 = Vector2.Distance(player2.transform.position, transform.position);

        if (distanceFromPlayer < lineOfSite || distanceFromPlayer2 < lineOfSite)
        {
            
            transform.position = Vector2.MoveTowards(this.transform.position, player1.transform.position, speed * Time.deltaTime);
            transform.position = Vector2.MoveTowards(this.transform.position, player2.transform.position, speed * Time.deltaTime);
        }

        
        //health & gun
        if (health <= 0)
        {
            Debug.Log(health);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //dead
            FindObjectOfType<MainManager>().endGame();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }

    public void TakeDamage(int damage)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        health -= damage;
    }
}
