using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrostingText : MonoBehaviour
{
    [SerializeField] private Text frostingText;
    [SerializeField] private Text sprinklesText;
    [SerializeField] private Text coffeeText;

    void Start()
    {

    }

    void Update()
    {
        if(Movement.Frosted == true)
        {
            frostingText.gameObject.SetActive(true);
        }else if(Movement.Frosted == false)
        {
            frostingText.gameObject.SetActive(false);
        }

        if (Movement.sprinkled == true)
        {
            sprinklesText.gameObject.SetActive(true);
        }
        else if(Movement.sprinkled == false)
        {
            sprinklesText.gameObject.SetActive(false);
        }

        if(Movement.slowed == true)
        {
            coffeeText.gameObject.SetActive(true);
        }
        else if(Movement.slowed == false)
        {
            coffeeText.gameObject.SetActive(false);
        }

    }
}
