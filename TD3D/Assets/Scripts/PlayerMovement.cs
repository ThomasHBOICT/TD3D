using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float vertMuliplier;

    public Animator animator;

    private Rigidbody rb;
    private Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Run();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

    private void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical") * vertMuliplier;


        if (movement.x > 0)
        {
            //transform.localScale = new Vector3(-2.5f, 2.5f, 2.5f);
            transform.localRotation = Quaternion.Euler(0, -180, 0);
        }
        if (movement.x < 0)
        {
            //transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        animator.SetFloat("speedX", System.Math.Abs(movement.x));

        animator.SetFloat("speedZ", movement.z);
    }

    private void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed *= 1.5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed /= 1.5f;
        }
    }
}
