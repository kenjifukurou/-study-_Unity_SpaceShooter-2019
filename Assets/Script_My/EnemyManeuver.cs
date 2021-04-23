using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManeuver : MonoBehaviour
{
    public float maneuverPower;
    public float smoothing;

    public Vector2 randomTimeStart;
    public Vector2 maneuverTime;
    public Vector2 waitTime;
    public Vector2 speedV;

    public float tilt;

    private float maneuverToTarget;
    private Rigidbody rb;
    private float currentSpeed;

    public Boundary boundary;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = Random.Range(speedV.x, speedV.y);
        StartCoroutine(Maneuver());
    }

    IEnumerator Maneuver()
    {
        yield return new WaitForSeconds(Random.Range(randomTimeStart.x, randomTimeStart.y));

        while(true)
        {
            maneuverToTarget = Random.Range(1, maneuverPower) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            maneuverToTarget = 0;
            yield return new WaitForSeconds(Random.Range(waitTime.x, waitTime.y));
        }
    }
    
    void FixedUpdate()
    {
        float newManeuver = Mathf.MoveTowards(rb.velocity.x, maneuverToTarget, Time.deltaTime * smoothing);
        rb.velocity = new Vector3(newManeuver, 0.0f, -currentSpeed);
        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
