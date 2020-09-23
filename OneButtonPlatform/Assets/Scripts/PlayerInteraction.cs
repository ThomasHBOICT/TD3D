using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [HideInInspector]
    public PlayerMovement playermove;
    public GameObject sword;

    private bool isHitting = false;
    // Start is called before the first frame update
    void Start()
    {
        playermove = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Hit();
    }

    private void Hit()
    {
        if (playermove.canJump == false && isHitting == false)
        {
            if (Input.anyKeyDown || Input.touchCount > 0)
            {
                Debug.Log("sword slash");
                StartCoroutine("HitNum");
            }
        }
    }

    private IEnumerator HitNum()
    {
        isHitting = true;
        sword.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        sword.SetActive(false);
        isHitting = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Fly")
        {
            Debug.Log("Player is hit");
        }
    }
}
