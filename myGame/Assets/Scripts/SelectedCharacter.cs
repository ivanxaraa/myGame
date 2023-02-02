using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCharacter : MonoBehaviour
{
    Powers scriptPower;

    public int currentCharacterIndex = 0;
    public GameObject[] Characters;

    public Camera Camera0;
    public Camera Camera1;
    public GameObject Bg0;
    public GameObject Bg1;
    public GameObject Canvas0;
    public GameObject Canvas1;



    

    void Start()
    {
        scriptPower = GetComponent<Powers>();

        currentCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (GameObject Character in Characters)
            Character.SetActive(false);

        Characters[currentCharacterIndex].SetActive(true);

        

        
    }

    private void Update()
    {

        switch (currentCharacterIndex)
        {
            case 0:
                Camera0.enabled = true;
                Camera1.enabled = false;
                Bg0.SetActive(true);
                Bg1.SetActive(false);
                Canvas0.SetActive(true);
                Canvas1.SetActive(false);
                scriptPower.jogador = 0;
                
                break;
            case 1:
                Camera0.enabled = false;
                Camera1.enabled = true;
                Bg0.SetActive(false);
                Bg1.SetActive(true);
                Canvas0.SetActive(false);
                Canvas1.SetActive(true);
                scriptPower.jogador = 1;
                
                break;
        }

    }






}
