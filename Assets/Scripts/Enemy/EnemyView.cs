using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using UnityEngine.Events;

public class EnemyView : ObjectView<IEnemyModel>
{
    private UnityAction _onHitBullet;
    protected override void InitRenderModel(IEnemyModel model)
    {
        transform.position = model.pos;
    }

    protected override void UpdateRenderModel(IEnemyModel model)
    {
        transform.position = model.pos;
    }

    public void SetCallbacks( UnityAction onHitBullet)
    {
        _onHitBullet = onHitBullet;

    }

    public void Update()
    {
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        bool isHitEnemy = collision.gameObject.CompareTag("Bullet");

        if (isHitEnemy)
        {
            //collision.gameObject.SetActive(false);
            _onHitBullet?.Invoke();
        }
    }
}
