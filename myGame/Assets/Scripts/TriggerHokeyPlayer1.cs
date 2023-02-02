using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHokeyPlayer1 : MonoBehaviour
{
    public GameObject controller1;
    private float duration = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        controller1.GetComponent<BoxCollider2D>().enabled = true;
        Invoke("TiraBox", duration);
        
    }


    void TiraBox()
    {
        controller1.GetComponent<BoxCollider2D>().enabled = false;
    }
}
