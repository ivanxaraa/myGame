using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public Transform playerPos;
    public TextMeshProUGUI textScore;

    public TextMeshProUGUI HighScore;
    public TextMeshProUGUI HighScore2;


    

    private void Start()
    {
        HighScore.text = "HighScore: " + PlayerPrefs.GetFloat("HighScore", 0).ToString("0");
        HighScore2.text = "HighScore: " + PlayerPrefs.GetFloat("HighScore", 0).ToString("0");
    }

    void Update()
    {
        textScore.text = playerPos.position.x.ToString("0") + "m";

        if(playerPos.position.x > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", playerPos.position.x);
            HighScore.text = "HighScore: " + playerPos.position.x.ToString("0");
            HighScore2.text = "HighScore: " + playerPos.position.x.ToString("0");
        }             

    }

    public void reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
        PlayerPrefs.SetFloat("HighScore", 0);
        HighScore.text = "HighScore: 0";
        HighScore2.text = "HighScore: 0";
    }
}
