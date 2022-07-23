using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public Animator animator;
    public AudioSource click;
    public void Retry()
    {
        Movement.Frosted = false;
        Movement.sprinkled = false;
        Movement.slowed = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        animator.SetBool("Slide", false);
        Time.timeScale = 1f;
    }
    public void ReturnToMainMenu()
    {
        Movement.Frosted = false;
        Movement.sprinkled = false;
        Movement.slowed = false;
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
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
