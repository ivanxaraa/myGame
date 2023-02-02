using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalTerra : MonoBehaviour
{
    public GameObject level2;
    

    
    public GameObject anim1;
    public GameObject anim;

    public PlayerMovement playerMovement1;
    public PlayerMovement playerMovement2;

    public CharacterController2D controller1;
    public CharacterController2D controller2;

    public Transform target;

    public GameObject zero, one, two, three;
    public GameObject zero0, one1, two2, three3;

    public GameObject backgroundTerra1, backgroundTerra2;

    public SelectedCharacter selectedscript;
    
    

    private void Start()
    {
        
        anim1.SetActive(false);
        anim.SetActive(false);
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            

            playerMovement1.runSpeed -= playerMovement1.runSpeed;
            playerMovement2.runSpeed -= playerMovement2.runSpeed;
            anim1.SetActive(true);
            anim.SetActive(true);
            Invoke("SairDaAnimacaoTerra", 7f);

            controller1.transform.position = new Vector2(target.position.x, target.position.y);
            controller1.transform.rotation = target.transform.rotation;
            controller2.transform.position = new Vector2(target.position.x, target.position.y);


            desativar();

            switch (selectedscript.currentCharacterIndex)
            {
                case 0:                    
                    backgroundTerra1.SetActive(true);
                    backgroundTerra2.SetActive(false);
                    break;
                case 1:                    
                    backgroundTerra1.SetActive(false);
                    backgroundTerra2.SetActive(true);
                    break;
            }
        }
    }

    void SairDaAnimacaoTerra()
    {
        
        level2.SetActive(false);
        playerMovement1.runSpeed = 70;
        playerMovement2.runSpeed = 70;
        anim.SetActive(false);
    }

    void desativar()
    {
        zero.SetActive(false);
        one.SetActive(false);
        two.SetActive(false);
        three.SetActive(false);

        zero0.SetActive(false);
        one1.SetActive(false);
        two2.SetActive(false);
        three3.SetActive(false);

    }
}
