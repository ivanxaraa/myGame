using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WalletManager : MonoBehaviour
{
    public static WalletManager instance;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI textCanvas1;
    public TextMeshProUGUI textCanvas2;
    public int myBitcoins;
    public int myBitcoinsSemDescontar;
    public bool podeSomar = false;




    void Start()
    {
        podeSomar = true;

        if (instance == null)
        {
            instance = this;
        }
    }

    

    public void ChangeBitcoin(int coinValue)
    {
        myBitcoins += coinValue;        
    }

    public void Somar(int coinValue)
    {
        myBitcoinsSemDescontar += coinValue;
    }


    void Update() 
    {
        text1.text = myBitcoins.ToString();
        text2.text = myBitcoins.ToString();

        if(podeSomar == true) { 

        textCanvas1.text = myBitcoinsSemDescontar.ToString();
        textCanvas2.text = myBitcoinsSemDescontar.ToString();
        }

    }
}
