using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    private bool canJump;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public int force = 50;

    void FixedUpdate()
    {
        if (canJump)
        {
      
            canJump = false;
            rb.AddForce(0, force, 0, ForceMode.Impulse);
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            canJump = true;
        }
    }
}


