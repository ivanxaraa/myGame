using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveScript : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerMovement playerMovement2;
    public float speed;
    public float Acceleration;
    Rigidbody2D rb;    
    public float RotationControl;
    float MovY, MovX = 1;
    
    public bool podeMovimentar = false;
    



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        MovY = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.D)){
            speed += 1;
        }else if (Input.GetKeyDown(KeyCode.A))
        {
            speed -= 1;
        }

    }

    

    private void FixedUpdate()
    {
        if(podeMovimentar == true)
        {

            playerMovement.enabled = false;
            playerMovement2.enabled = false;
            Vector2 Vel = transform.right * (MovX * Acceleration);
        rb.AddForce(Vel);

        float Dir = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.right));

        if(Acceleration > 0)
        {
            if(Dir > 0)
            {
                rb.rotation += MovY * RotationControl * (rb.velocity.magnitude / speed);
            }
            else
            {
                rb.rotation -= MovY * RotationControl * (rb.velocity.magnitude / speed);
            }
        }

        float trustForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.down)) * 2.0f;

        Vector2 relForce = Vector2.up * trustForce;

        rb.AddForce(rb.GetRelativeVector(relForce));

        if(rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
        }
    }
}
