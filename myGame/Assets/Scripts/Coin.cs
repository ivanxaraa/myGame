using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int coinValue = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            WalletManager.instance.ChangeBitcoin(coinValue);
            WalletManager.instance.Somar(coinValue);

        }
    }
}
