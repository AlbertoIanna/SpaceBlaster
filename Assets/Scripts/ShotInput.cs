using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotInput : MonoBehaviour {

    [Header("Shoot Input Settings")]
    public KeyCode ShootKey = KeyCode.P;
    public Transform ShootPosition;

    public float ShootForce = 0.3f;

    BulletPoolManager bulletManager;
	// Use this for initialization
	void Start () {
        bulletManager = FindObjectOfType<BulletPoolManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(ShootKey))
        {
            Shoot();
        }	
	}

    void Shoot()
    {
        Bullet bulletToShoot = bulletManager.GetBullet();
        bulletToShoot.transform.position = ShootPosition.position;
        bulletToShoot.Shoot(transform.forward, ShootForce);
    }
}
