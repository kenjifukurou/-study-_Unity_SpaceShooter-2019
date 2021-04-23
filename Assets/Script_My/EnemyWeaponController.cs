using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : MonoBehaviour
{
    private AudioSource audioSource;

    public GameObject enemyShot;
    public Transform shotSpawnLocation;
    public float fireRate;
    public float fireDelay;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("EnemyFire", fireDelay, fireRate);
    }

    void EnemyFire()
    {
        audioSource.Play();
        Instantiate(enemyShot, shotSpawnLocation.position, shotSpawnLocation.rotation);
    }
}
