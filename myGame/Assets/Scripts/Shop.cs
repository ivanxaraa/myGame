using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    

    public GameObject container1;
    public GameObject container2;

    public GameObject Spellbinder1;
    public GameObject Spellbinder2;
    private bool SpellBinderCheck = false;
    private int SpellbinderPrice = 100;

    


    public bool jetpackCheck = false;
    private int jetpackPrice = 300;
    
    

    private bool dashCheck = false;
    private int dashPrice = 70;

    public CharacterController2D controller1;
    public CharacterController2D controller2;



    



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (collision.gameObject.tag == "Player")
            {

                container1.SetActive(true);
                container2.SetActive(true);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        container1.SetActive(false);
        container2.SetActive(false);
    }

    public void fechar()
    {
        container1.SetActive(false);
        container2.SetActive(false);
    } 

    public void ComprarSpellBinder()
    {
        if (WalletManager.instance.myBitcoins >= SpellbinderPrice) //spellBinder
        {

            if (SpellBinderCheck == false) 
            {
                Spellbinder1.SetActive(true);
                Spellbinder2.SetActive(true);
                SpellBinderCheck = true;
                WalletManager.instance.myBitcoins = WalletManager.instance.myBitcoins - SpellbinderPrice;
            }
            else
            {
                Debug.Log("already have this weapon");
            }
        }

        else
        {
            Debug.Log("cannot afford");
        }
    }

    public void ComprarDash()
    {

        if (WalletManager.instance.myBitcoins >= dashPrice) //spellBinder
        {

            if (dashCheck == false) 
            {
                controller1.dash = true;
                controller2.dash = true;
                
                dashCheck = true;
                WalletManager.instance.myBitcoins = WalletManager.instance.myBitcoins - dashPrice;
                
            }
            else
            {
                Debug.Log("already have dash");
            }
        }

        else
        {
            Debug.Log("cannot afford");          
        }

    }

    public void ComprarJetpack()
    {
        if (WalletManager.instance.myBitcoins >= jetpackPrice) //jetpack
        {

            if (jetpackCheck == false) 
            {
                                
                jetpackCheck = true;
                WalletManager.instance.myBitcoins = WalletManager.instance.myBitcoins - jetpackPrice;
            }
            else
            {
                Debug.Log("already have jetpack");
            }
        }

        else
        {
            Debug.Log("cannot afford");
        }
    }
   
}




