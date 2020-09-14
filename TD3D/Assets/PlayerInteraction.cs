using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Destroyable destroyableObject;
    public SpriteRenderer EButton;

    // Update is called once per frame
    void Update()
    {
        if (destroyableObject != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                destroyableObject.Hitting();
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                destroyableObject.StopHitting();
                if (destroyableObject == null)
                {
                    EButton.enabled = false;
                    destroyableObject.StopHitting();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Destroyable")
        {
            Debug.Log("tree in range");
            destroyableObject = other.GetComponent<Destroyable>();
            EButton.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Destroyable")
        {
            Debug.Log("tree no longer in range");
            EButton.enabled = false;
            if (destroyableObject != null)
            {
                destroyableObject.StopHitting();
            }
            destroyableObject = null;
        }
    }
}
