using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public Animator animator;
    public AudioSource playerAudio;

    public void GameOver()
    {
        animator.SetBool("Slide", true);
        playerAudio.Play();
    }
}
