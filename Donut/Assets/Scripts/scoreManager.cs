using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public Text scoreText;
    public static float scoreAmount;
    public static float highscoreAmount;
    public static float pointsPerSecond;

    void Start()
    {
        highscoreAmount = PlayerPrefs.GetInt("highscore", 0);

        scoreAmount = 0f;
        pointsPerSecond = 100f;
    }

    void Update()
    {
        if(Movement.alive == true)
        {
            scoreText.text = "" + (int)scoreAmount;
            scoreAmount += pointsPerSecond * Time.deltaTime;
        }
        if (highscoreAmount < scoreAmount)
        {
            PlayerPrefs.SetInt("highscore", (int)scoreAmount);
        }
    }
}
