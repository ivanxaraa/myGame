using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{

    public int currentCharacterIndex = 0;
    public GameObject[] CharacterModels;


    void Start()
    {
        currentCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (GameObject Character in CharacterModels)
            Character.SetActive(false);

        CharacterModels[currentCharacterIndex].SetActive(true);
    }


    
    void Update()
    {
        
    }

    public void ChangeNext()
    {
        CharacterModels[currentCharacterIndex].SetActive(false);
        currentCharacterIndex++;

        if (currentCharacterIndex == CharacterModels.Length)
            currentCharacterIndex = 0;

        CharacterModels[currentCharacterIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", currentCharacterIndex);
    }

    public void ChangePrevious()
    {
        CharacterModels[currentCharacterIndex].SetActive(false);
        currentCharacterIndex--;

        if (currentCharacterIndex == -1)
            currentCharacterIndex = CharacterModels.Length -1;

        CharacterModels[currentCharacterIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", currentCharacterIndex);
    }
}
