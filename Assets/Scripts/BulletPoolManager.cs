using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour {

    Vector3 poolPositionOutOfScreen = new Vector3(100, 100, 100);

    public Bullet BulletPrefab;
    public int MaxBullet = 20;

    List<Bullet> bullets = new List<Bullet>();

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < MaxBullet; i++)
        {
            Bullet balletToAdd = Instantiate(BulletPrefab);
            balletToAdd.OnShot += OnBulletShot;
            balletToAdd.OnDestroy += OnBulletDestroy;
            OnBulletDestroy(balletToAdd);
            bullets.Add(balletToAdd);
        }
    }

    public void OnDisable()
    {
        foreach (Bullet bullet in bullets)
        {
            bullet.OnShot -= OnBulletShot;
            bullet.OnDestroy -= OnBulletDestroy;
        }
    }

    private void OnBulletShot (Bullet bullet)
    {

    }
    
    private void OnBulletDestroy (Bullet bullet)
    {
        // Move bullet out of Screen
        bullet.transform.position = poolPositionOutOfScreen;
    }

    public Bullet GetBullet()
    {
        Bullet returnBallet = null;

        foreach (Bullet bullet in bullets)
        {
            if (bullet.CurrentState == Bullet.State.InPool)
            {
                return bullet;
            }
        }
        Debug.Log("Pool Esaurito");
        return returnBallet;
    }

 

}
