using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodMover : MonoBehaviour
{
    private float randomSpeedH;
    private float randomSpeedV;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        randomSpeedH = 2 * Random.value;
        randomSpeedV = Random.Range(5, 20);
        rb.velocity = new Vector3(Random.value * randomSpeedH, 0.0f, -randomSpeedV);
    }
}
