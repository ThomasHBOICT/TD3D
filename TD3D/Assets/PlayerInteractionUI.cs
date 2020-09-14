using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionUI : MonoBehaviour
{
    public GameObject EButton;
    public float moveSpeed;

    private bool outOfRange;

    // Start is called before the first frame update
    void Update()
    {
       if (outOfRange)
        {
            EButton.transform.position = Vector3.Lerp(EButton.transform.position, transform.position,  moveSpeed * Time.deltaTime);
        } 
    }

    // Update is called once per frame
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Button")
        {
            outOfRange = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button")
        {
            outOfRange = false;
        }
    }
}
