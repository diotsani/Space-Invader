using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using Agate.MVC.Core;
using UnityEngine.Events;
using UnityEngine;

public class BulletView : ObjectView<IBulletModel>
{
    private UnityAction _onMoveBullet;
    private UnityAction _onHitEnemy;

    protected override void InitRenderModel(IBulletModel model)
    {
        transform.position = model.BulletPosition;
    }

    protected override void UpdateRenderModel(IBulletModel model)
    {
        transform.position = model.BulletPosition;
    }

    public void SetCallbacks(UnityAction onMoveBullet, UnityAction onHitEnemy)
    {
        _onMoveBullet = onMoveBullet;
        _onHitEnemy = onHitEnemy;

        //Debug.Log("_onmove");
    }

    public void Update()
    {
        _onMoveBullet?.Invoke(); // Fungsi Move Bullet
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        bool isHitEnemy = collision.gameObject.CompareTag("Enemy");

        if(isHitEnemy)
        {
            collision.gameObject.SetActive(false);
            _onHitEnemy?.Invoke();
        }
    }
}
