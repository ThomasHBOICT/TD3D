using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDirection : MonoBehaviour
{
    public static float rotationSpeed;
    private Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        tf.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    public void ResetRotation()
    {
        tf.localRotation = Quaternion.identity;
    }
}
