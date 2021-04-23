using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float tiltX;
    public float tiltY;
    public float tiltZ;

    public Boundary boundary;

    public GameObject boltPrefab;
    public Transform boltSpawn;
    public float fireRate;
    private float nextFire;

    public AudioSource audioShoot;

    private Quaternion calibrationQuaternion;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //speed = 5;
        //tiltX = 1;
        //tiltY = 35;
        //tiltZ = -50;
        boundary.xMin = -8;
        boundary.xMax = 8;
        boundary.zMin = -1;
        boundary.zMax = 5;
        //fireRate = 0.2f;

        audioShoot = GetComponent<AudioSource>();

        CalibrateAccelerometer();
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(boltPrefab, boltSpawn.position, boltSpawn.rotation);
            audioShoot.Play();
        }
    }

    void CalibrateAccelerometer()
    {
        Vector3 accelerationSnap = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), accelerationSnap);
        calibrationQuaternion = Quaternion.Inverse(rotateQuaternion);
    }

    Vector3 FixAcceleration (Vector3 acceleration)
    {
        Vector3 fixedAcceleration = calibrationQuaternion * acceleration;
        return fixedAcceleration;
    } 

    void FixedUpdate()
    {
        // input for PC
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        // input for Mobile using tilt
        //Vector3 accelerationRaw = Input.acceleration;
        //Vector3 acceleration = FixAcceleration(accelerationRaw);
        //Vector3 movement = new Vector3(acceleration.x, 0, acceleration.y);

        rb.velocity = movement * speed;

        //constraint position
        float xPos = Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax);
        float zPos = Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax);
        rb.position = new Vector3(xPos, 0, zPos);

        //rb.rotation = Quaternion.Euler(0.0f, acceleration.x * tiltY, acceleration.x * tiltZ);
        //rb.rotation = Quaternion.Euler(0.0f, moveHorizontal.x * tiltY, moveVertical.x * tiltZ);
    }
}