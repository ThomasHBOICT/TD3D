using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Fly")
        {
            player.canJump = true;
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fly")
        {
            player.canJump = true;
        }
    }
}
