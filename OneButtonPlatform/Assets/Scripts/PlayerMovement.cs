using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce;
    public float jumpRotation;
    public GameObject jumpDirection;

    public bool canJump = true;

    private Rigidbody2D rb;

    private Animator playerAnimation;
    private SpriteRenderer sprite;
    private JumpDirectionTicker directionScript;
    public SpriteRenderer jumpArrow;

    public ScoreObject highScore;
    public ScoreObject currentScore;

    // Start is called before the first frame update
    void Start()
    {
        currentScore.@float = 0;
        Time.timeScale = 0;
        rb = GetComponent<Rigidbody2D>();
        JumpDirection.rotationSpeed = jumpRotation;
        playerAnimation = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        directionScript = GetComponentInChildren<JumpDirectionTicker>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        JumpActiveVisual();
        ScoreUpdater();
    }

    private void Jump()
    {
        if (Input.anyKeyDown && canJump || Input.touchCount > 0 && canJump)
        {
            if (Time.timeScale < 0.1)
            {
                Time.timeScale = 1;
            }
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(jumpDirection.transform.up * jumpForce);
            rb.gravityScale = 1f;
            canJump = false;
            playerAnimation.SetBool("isJumping", true);
            directionScript.isOnLeftWall = false;
            directionScript.isOnRightWall = false;

            if (directionScript.tickerRightSide)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
            directionScript.FlipDirection();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall")
        {
            CanJump();
        }
        if (collision.collider.tag == "LeftWall")
        {
            directionScript.isOnLeftWall = true;
            CanJump();
        }
        if (collision.collider.tag == "RightWall")
        {
            directionScript.isOnRightWall = true;
            CanJump();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall")
        {
            rb.gravityScale = 1f;
        }
    }

    private void CanJump()
    {
        playerAnimation.SetBool("isJumping", false);
        rb.gravityScale = 0.2f;
        canJump = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Orb")
        {
            collision.GetComponent<Orb>().Pickup();
            canJump = true;
        }
    }

    private void JumpActiveVisual()
    {
        if (canJump)
        {
            jumpArrow.color = new Color(1, 1, 1, 1);
        }
        else
        {
            jumpArrow.color = new Color(1, 1, 1, 0.2f);
        }
    }

    private void ScoreUpdater()
    {
        if (transform.position.y > highScore.@float)
        {
            highScore.@float = transform.position.y;
        }
        if (transform.position.y > currentScore.@float)
        {
            currentScore.@float = transform.position.y;
        }
    }
}
