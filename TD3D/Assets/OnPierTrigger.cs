using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPierTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.layer = 8;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.layer = 0;
        }
    }
}
