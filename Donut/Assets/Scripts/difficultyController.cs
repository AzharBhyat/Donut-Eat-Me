using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficultyController : MonoBehaviour
{

    public float difficultyLevel = 0.4f;
    public float difficultyIncrement = 0.2f;
    public float difficultyInterval = 5f;

    void FixedUpdate()
    {

        if (difficultyInterval <= 0f)
        {
            difficultyInterval = 5f;
            difficultyLevel += difficultyIncrement;
        }
        else
        {
            difficultyInterval -= Time.fixedDeltaTime;
        }
    }


}
