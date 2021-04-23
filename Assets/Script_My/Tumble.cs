using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tumble : MonoBehaviour
{
    public float tumble;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tumble = 5;
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
