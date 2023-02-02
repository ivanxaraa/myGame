using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NaveFollow : MonoBehaviour
{
    public CharacterController2D controller;
    public CharacterController2D controller2;    
    public NaveScript NaveScript;
    PlayerMovement playerMovement;

    public GameObject contaKMh1;
    public GameObject contaKMh2;



    public Transform navePos;
    public bool seguirNave = false;
    private float distanciaPlayerNave = 0.4f;

    public TextMeshProUGUI velocityText1;
    public TextMeshProUGUI velocityText2;

    private bool shhet = false;

    private void Start()
    {
        contaKMh1.SetActive(false);
        contaKMh2.SetActive(false);

        velocityText1.enabled = false;
        velocityText2.enabled = false;

        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (seguirNave == true)
        {
            controller.GetComponent<Animator>().Play("Player_Nave");
            controller.transform.position = new Vector2(navePos.transform.position.x, navePos.transform.position.y + distanciaPlayerNave);
            



            controller2.GetComponent<Animator>().Play("Player3_Nave");
            controller2.transform.position = new Vector2(navePos.transform.position.x, navePos.transform.position.y + distanciaPlayerNave);
            controller2.transform.rotation = navePos.rotation;

            velocityText1.text = NaveScript.speed.ToString();
            velocityText2.text = NaveScript.speed.ToString();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if (collision.gameObject.CompareTag("Nave"))
        {
            if(shhet == false)
            {
                shhet = true;
                NaveScript.speed = 6;
            }

            contaKMh1.SetActive(true);
            contaKMh2.SetActive(true);

            velocityText1.enabled = true;
            velocityText2.enabled = true;

            playerMovement.enabled = false;
            seguirNave = true;
            NaveScript.podeMovimentar = true;
            
        }

        
    }
}
