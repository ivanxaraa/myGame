using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour
{
    public GameObject gameCompleted;
    public GameObject gameCompleted1;


    public PlayerMovement controller;
    public PlayerMovement controller1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        controller.GetComponent<Rigidbody2D>().gravityScale = 0;
        controller1.GetComponent<Rigidbody2D>().gravityScale = 0;

        gameCompleted.SetActive(true);
        controller.enabled = false;

        gameCompleted1.SetActive(true);
        controller1.enabled = false;
    }
}
