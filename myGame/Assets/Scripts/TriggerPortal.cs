using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPortal : MonoBehaviour
{
    public Portal portalscript;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        portalscript.portalMoves = true;
    }
}
