using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmLand : MonoBehaviour
{

    public Transform interactionPoint;
    public GameObject farmedLand;

    private bool farmInRange = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FarmGround();
    }

    private void FarmGround()
    {
        if (Input.GetKeyDown(KeyCode.Q) && farmInRange == false)
        {
            Instantiate(farmedLand, interactionPoint.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Farm")
        {
            farmInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Farm")
        {
            farmInRange = false;
        }
    }
}