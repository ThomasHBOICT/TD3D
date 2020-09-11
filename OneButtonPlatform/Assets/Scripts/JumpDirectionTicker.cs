using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDirectionTicker : MonoBehaviour
{
    public float waitTime;
    public bool tickerRightSide = true;
    public bool isOnWall;
    public bool isOnLeftWall;
    public bool isOnRightWall;

    int flipDirection = 45;
    private float timer;
    private Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }
    /*
    private void FixedUpdate()
    {
        //ChangeRotation();
    }
    
    private void ChangeRotation()
    {
        if (isOnLeftWall)
        {
            tickerRightSide = false;
            tf.localRotation = Quaternion.Euler(0, 0, -45);
        }
        if (isOnRightWall)
        {
            tickerRightSide = true;
            tf.localRotation = Quaternion.Euler(0, 0, 45);
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > waitTime)
            {
                flipDirection *= -1;
                tf.localRotation = Quaternion.Euler(0, 0, flipDirection);
                tickerRightSide = !tickerRightSide;
                timer = 0;
            }
        }
       
    }*/

    public void FlipDirection()
    {
        if (isOnLeftWall)
        {
            tickerRightSide = false;
            tf.localRotation = Quaternion.Euler(0, 0, -45);
        }
        if (isOnRightWall)
        {
            tickerRightSide = true;
            tf.localRotation = Quaternion.Euler(0, 0, 45);
        }
        flipDirection *= -1;
        tf.localRotation = Quaternion.Euler(0, 0, flipDirection);
        tickerRightSide = !tickerRightSide;
    }
}
