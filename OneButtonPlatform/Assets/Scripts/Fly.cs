using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public float moveRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();   
    }

    private void Move()
    {
        if (rb.position.x < moveRange)
        {
            rb.MovePosition(rb.position + new Vector2(4, 0) * moveSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Sword")
        {
            Debug.Log("Fly destroyed, ouch");
            Destroy(gameObject);
        }
        moveSpeed *= -1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sword")
        {
            Debug.Log("Fly destroyed, ouch");
            Destroy(gameObject);
        }
    }
}
