using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHand : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Destroy(this.gameObject);
        }
    }
}
