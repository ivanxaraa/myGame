using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public PlayerMovement playerMovement1;
    public PlayerMovement playerMovement2;
    public CharacterController2D controller1;
    public CharacterController2D controller2;

    public Transform target;

    public NaveFollow NaveFollow1;
    public NaveFollow NaveFollow2;
    public NaveScript NaveScript;

    public Animator animator1;
    public Animator animator2;

    public GameObject animationPortal1;
    public GameObject animationPortalFlash1;
    public GameObject animationPortal2;
    public GameObject animationPortalFlash2;

    public GameObject contaKLH1, contaKLH2;

    public bool portalMoves = false;
   




    void Update()
    {
        if(portalMoves == true)
        { 
        transform.position = new Vector2(transform.position.x, controller2.transform.position.y);
        transform.position = new Vector2(transform.position.x, controller1.transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        contaKLH1.SetActive(false);
        contaKLH2.SetActive(false);

        playerMovement1.runSpeed -= playerMovement1.runSpeed;
        playerMovement2.runSpeed -= playerMovement2.runSpeed;

        animationPortal1.SetActive(true);
        animationPortal2.SetActive(true);
        Invoke("SairDaAnimacao", 5.5f);

        playerMovement1.enabled = true;
        playerMovement2.enabled = true;

        NaveFollow1.enabled = false;
        NaveFollow2.enabled = false;
        NaveScript.enabled = false;

        NaveFollow2.velocityText1.enabled = false;
        NaveFollow2.velocityText2.enabled = false;

        if (collision.gameObject.CompareTag("Nave") || collision.gameObject.CompareTag("Player"))
        {
            controller1.transform.position = new Vector2(target.position.x, target.position.y);
            controller2.transform.position = new Vector2(target.position.x, target.position.y);
            
            animator1.SetTrigger("SairDaNave");

            controller1.transform.rotation = target.transform.rotation;
            controller2.transform.rotation = target.transform.rotation;
            animator2.SetTrigger("SairDaNave");
        }

        portalMoves = false;

        //animations
        

    }

    void SairDaAnimacao()
    {
        animationPortalFlash1.SetActive(true);
        animationPortal1.SetActive(false);
        animationPortalFlash2.SetActive(true);
        animationPortal2.SetActive(false);
        Invoke("SairDaAnimacaoFlash", 2.5f);
    }

    void SairDaAnimacaoFlash()
    {
        playerMovement1.runSpeed = 70;
        playerMovement2.runSpeed = 70;
        animationPortalFlash1.SetActive(false);
        animationPortalFlash2.SetActive(false);
    }
}
