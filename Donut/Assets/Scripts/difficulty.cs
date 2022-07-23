using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficulty : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject diffController;

    private void Start()
    {
        diffController = GameObject.FindWithTag("forkspawner");
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = diffController.gameObject.GetComponent<difficultyController>().difficultyLevel;
    }

    private void Update()
    {
        rb.gravityScale = diffController.gameObject.GetComponent<difficultyController>().difficultyLevel;
    }
}
