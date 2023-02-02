using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    public float speed = 50f;
    public float distance = 2f;
    private bool movingRight = true;

    public Transform groundDetection;

    //health & gun    
    public int health = 10;
    public GameObject deathEffect;
    public GameObject explosion;

    private void Update()
    {
        //movement
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

        //health & gun
        if (health <= 0)
        {
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

    public void TakeDamage(int damage)
    {        
        Instantiate(explosion, transform.position, Quaternion.identity);
        health -= damage;
    }
}




