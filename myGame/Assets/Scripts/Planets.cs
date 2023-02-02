using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour
{
    private GameObject Nave;
    public MainManager MainManager;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Nave = GameObject.FindGameObjectWithTag("Nave");
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.gameObject.CompareTag("Nave"))
            {
            Nave.SetActive(false);
            player.SetActive(false);
            MainManager.endGame();
            }
        
    }

  

}
