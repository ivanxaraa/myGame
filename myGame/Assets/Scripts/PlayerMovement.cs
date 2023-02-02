using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public ParticleSystem dust;
    public ParticleSystem dustLand;


    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;



    

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (controller.m_Grounded == true && Input.GetButtonDown("Jump"))
        {
            
            animator.SetTrigger("TakeOff");
            jump = true;
            CreateDust();
            
        }

        if(controller.m_Grounded == true)
        {            
            animator.SetBool("isJumping", false);
           
            
        }
        else
        {
            CreateDustLand();
            animator.SetBool("isJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        

    }

    

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }

    void CreateDust()
    {
        dust.Play();
    }

    void CreateDustLand()
    {
        dustLand.Play();
    }


    //coins
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
        }
                
    }


}
