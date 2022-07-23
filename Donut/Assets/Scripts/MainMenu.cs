using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource click;
    public GameObject usernameCanvas;

    public void PlayGame()
    {
        if (PlayerPrefs.HasKey("username") == false)
        {
            usernameCanvas.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void ClickSound()
    {
        click.Play();
    }

}
