using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{    



    public void Play()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void ChooseCharacter()
    {
        SceneManager.LoadScene("ShopMenu");
    }

    public void Sair()
    {
        Application.Quit();
    }
}
