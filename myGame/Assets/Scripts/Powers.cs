using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour
{
    //VARIAVEIS 
    public ParticleSystem particulas;
    public float multiplier = 2.4f;
    public int increaseSpeed = 100;
    private float increaseJump = 800;


    public float durationSpeed = 5f;
    public float durationHokey = 4f;
    private float durationJump = 15f;

    private float durationMini = 20f;
    public JetPack jetPack1;
    public JetPack jetPack2;

    public float Player;

    //nave
    public float increaseSpeedNave = 3;

    PlayerMovement scriptMovement;
    public CharacterController2D controller;
    public CharacterController2D controller2;
    public NaveScript Nave;

    private void Start()
    {
        //Debug.Log(Player);
    }
    //PICK UP 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        particulas.Play();

        if(Player == 0)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            if (gameObject.tag == "Speed")
            {
                scriptMovement = player.GetComponent<PlayerMovement>();
                scriptMovement.runSpeed += increaseSpeed;

                //nave 
                Nave.speed += increaseSpeedNave;

                yield return new WaitForSeconds(durationSpeed);
                scriptMovement.runSpeed -= increaseSpeed; //voltar ao normal
                Nave.speed -= increaseSpeed;



            }
            else if (gameObject.tag == "Hokey")
            {
                controller2.m_AirControl = false;
                controller2.m_MovementSmoothing = 1;
                controller.m_AirControl = false;
                controller.m_MovementSmoothing = 1;

                yield return new WaitForSeconds(durationHokey);
                controller.m_AirControl = true;
                controller2.m_AirControl = true;
                controller.m_MovementSmoothing = 0.062f;
                controller2.m_MovementSmoothing = 0.062f;
            }
            else if (gameObject.tag == "Jump")
            {
                controller.m_JumpForce += increaseJump;
                controller2.m_JumpForce += increaseJump;

                yield return new WaitForSeconds(durationJump);

                controller.m_JumpForce -= increaseJump;
                controller2.m_JumpForce -= increaseJump;
            }
            else if (gameObject.tag == "Mini")
            {
                Debug.Log("Pegou mini");
                controller.transform.localScale = new Vector3(0.241564f, 0.241564f, controller.transform.localScale.z);
                controller2.transform.localScale = new Vector3(0.1206674f, 0.1206674f, controller.transform.localScale.z);
                jetPack1.speed += 3;
                jetPack2.speed += 3;


                yield return new WaitForSeconds(durationMini);

                controller.transform.localScale = new Vector3(0.4f, 0.4f, controller.transform.localScale.z);
                controller2.transform.localScale = new Vector3(0.196208f, 0.196208f, controller.transform.localScale.z);
                jetPack1.speed -= 3;
                jetPack2.speed -= 3;

            }


            Destroy(gameObject);

        }
        
    }

    
}
