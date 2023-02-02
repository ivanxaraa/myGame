using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{

    public int speed, jumpForce;

    Rigidbody2D rb;



    bool left;

    public ParticleSystem jetParticles;
    public GameObject jetpackItem;

    public Loja lojascript;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if(lojascript.jetpackCheck == true)
        {
            jetpackItem.SetActive(true);


            if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
            
        }
        if (Input.GetKey(KeyCode.Space))
        {
            jetParticles.Play();
            rb.AddForce(Vector2.up * jumpForce);
        }

        }
    }
}
