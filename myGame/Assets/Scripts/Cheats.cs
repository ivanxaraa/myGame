using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    public Transform navePos, portalTerraPos, enemiesPos, cloudPos, metaPos;

    public CharacterController2D controller1;
    public CharacterController2D controller2;

    public WalletManager walletScript;

    private bool letra1 = false;
       

    public GameObject canvas1;
    public GameObject canvas2;


    private void Update()
    {

        if (Input.GetKey(KeyCode.O) & letra1 == false)
        {
            
            letra1 = true;            
        }

        if (Input.GetKey(KeyCode.I) & letra1 == true)
        {
            
            letra1 = false;            
            canvas1.SetActive(true);
            canvas2.SetActive(true);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {                        
            canvas1.SetActive(false);
            canvas2.SetActive(false);
        }

    }


    public void darCoins()
    {
        walletScript.myBitcoins += 20;
    }

    public void tirarCoins()
    {
        walletScript.myBitcoins -= 20;
    }



    public void IrNavePos()
    {
        controller1.transform.position = new Vector2(navePos.position.x, navePos.position.y);
        controller2.transform.position = new Vector2(navePos.position.x, navePos.position.y);
        
    }

    public void IrPortalTerraPos()
    {
        controller1.transform.position = new Vector2(portalTerraPos.position.x, portalTerraPos.position.y);
        controller2.transform.position = new Vector2(portalTerraPos.position.x, portalTerraPos.position.y);
        
    }

    public void IrEnemiesPos()
    {
        controller1.transform.position = new Vector2(enemiesPos.position.x, enemiesPos.position.y);
        controller2.transform.position = new Vector2(enemiesPos.position.x, enemiesPos.position.y);
        
    }

    public void IrcloudPos()
    {
        controller1.transform.position = new Vector2(cloudPos.position.x, cloudPos.position.y);
        controller2.transform.position = new Vector2(cloudPos.position.x, cloudPos.position.y);
        
    }

    public void IrMetaPos()
    {
        controller1.transform.position = new Vector2(metaPos.position.x, metaPos.position.y);
        controller2.transform.position = new Vector2(metaPos.position.x, metaPos.position.y);

    }

    public void fechar()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(false);
    }
    

}
