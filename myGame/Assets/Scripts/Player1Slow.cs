using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Slow : MonoBehaviour
{

    public BoxCollider2D player1;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player1.enabled = true;
        Invoke("para", 3f);
    }




    void para()
    {
        player1.enabled = false;
    }
}
