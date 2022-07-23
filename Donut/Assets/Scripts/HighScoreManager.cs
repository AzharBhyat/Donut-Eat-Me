using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public Text highscoreText;

    void Update()
    {
        highscoreText.text = "" + PlayerPrefs.GetInt("highscore");
    }
}
