using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_PU : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Frosted")
        {
            Destroy(gameObject);
        }
    }

}
