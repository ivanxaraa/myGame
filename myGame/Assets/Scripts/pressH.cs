using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressH : MonoBehaviour
{
    public GameObject pressH1;
    public GameObject pressH2;


    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {

            pressH1.SetActive(false);
            pressH2.SetActive(false);

        }


    }
}
