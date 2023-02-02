using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SwapSide : MonoBehaviour
{
    public bool oneTimeOnly = true;
    public CharacterController2D controller;
    public GameObject DeactivateObjects;

    public TextMeshProUGUI velocityText1;
    public TextMeshProUGUI velocityText2;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (oneTimeOnly == true)
            {
                velocityText1.enabled = false;
                velocityText2.enabled = false;
                controller.podeVirar = true;
                gameObject.SetActive(false);
                DeactivateObjects.SetActive(false);
            }
        }
        

    }
}
