using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public BulletEvent OnShot;
    public BulletEvent OnDestroy;

    public State CurrentState = State.InPool;

    private void OnCollisionEnter(Collision collision)
    {
        if (CurrentState == State.InUse)
            DestroyMe();
    }

    private void Update()
    {
        if(CurrentState == State.InUse)
        {
            transform.position += direction * force;
        }
    }

    #region API

    Vector3 direction;
    float force;

    public void Shoot(Vector3 _direction, float _force)
    {
        CurrentState = State.InUse;
        if (OnShot != null)
        {
            OnShot(this);
        }
        direction = _direction;
        force = _force;
    }

    public void DestroyMe()
    {
        CurrentState = State.InPool;
        if (OnDestroy != null)
            OnDestroy(this);
    }

    #endregion

    #region Dichiarazioni Tipi

    public delegate void BulletEvent(Bullet bullet);

    public enum State
    {
        InPool,
        InUse,
    }
    #endregion

}
