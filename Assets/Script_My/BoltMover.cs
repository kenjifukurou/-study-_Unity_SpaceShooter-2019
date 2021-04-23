using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMover : MonoBehaviour
{
    public Rigidbody rb;
    public float boltSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boltSpeed = 15;
        rb.velocity = transform.forward * boltSpeed;
    }
}
