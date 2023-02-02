using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;



    public GameObject destroyEffect;

    
    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null) {
            Debug.Log(hitInfo.collider.tag);
            if (hitInfo.collider.CompareTag("Enemy")) {                
                hitInfo.collider.GetComponent<AIPatrol>().TakeDamage(damage);                
                Debug.Log(hitInfo.collider.tag);
            }else if (hitInfo.collider.CompareTag("EnemyFly"))
            {
                hitInfo.collider.GetComponent<FlyEnemy>().TakeDamage(damage);
            }
            
            DestroyProjectile();
        }


        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile() {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
