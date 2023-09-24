using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControll : MonoBehaviour
{
    public float maxspeed;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(rb.velocity.magnitude > maxspeed)
        {
            rb.velocity= rb.velocity.normalized * maxspeed;
        }
    }
}
