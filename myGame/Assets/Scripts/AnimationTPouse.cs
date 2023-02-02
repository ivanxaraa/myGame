using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTPouse : MonoBehaviour
{
    public GameObject NPC;
    public GameObject NPC2;

    private void Update()
    {



        if (Input.GetButtonDown("1Key"))
        {
            NPC.GetComponent<Animator>().Play("Player_TPouse");
            NPC2.GetComponent<Animator>().Play("Player3_TPouse");
        }
    }
}

