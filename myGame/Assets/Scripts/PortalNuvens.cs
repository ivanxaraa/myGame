using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalNuvens : MonoBehaviour
{
    public CharacterController2D controller1;
    public CharacterController2D controller2;

    public Transform target;

    private GameObject player;

    public GameObject backgroundTerra1, backgroundTerra2;
    public GameObject backgroundNuvens1, backgroundNuvens2;

    public GameObject zero, one, two, three;
    public GameObject zero0, one1, two2, three3;

    private void Start()
    {
        
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        transform.position = new Vector2(transform.position.x, player.transform.position.y);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        controller1.transform.position = new Vector2(target.position.x, target.position.y);
        controller2.transform.position = new Vector2(target.position.x, target.position.y);

        zero.SetActive(false);
        one.SetActive(false);
        two.SetActive(false);
        three.SetActive(false);

        zero0.SetActive(false);
        one1.SetActive(false);
        two2.SetActive(false);
        three3.SetActive(false);

        backgroundTerra1.SetActive(false);
        backgroundTerra2.SetActive(false);
               
        backgroundNuvens1.SetActive(true);
        backgroundNuvens2.SetActive(true);


    }
}
