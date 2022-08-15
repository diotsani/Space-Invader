using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using System;

public class BulletPoolController : ObjectController<BulletPoolController,BulletPoolModel,IBulletPoolModel,BulletPoolView>
{
    public override IEnumerator Finalize()
    {
        yield return base.Finalize();
    }
    public override void SetView(BulletPoolView view)
    {
        base.SetView(view);
        //InitPoolBullet();
    }

    public void OnStartPlay(StartPlayMessage messege)
    {
        //_view.SetCallbacks(InitPoolBullet);
    }

    public void InitPoolBullet(StartPlayMessage message)
    {
        if(_model.pooledBullets.Count < _model.maxBullet)
        {
            GameObject bullet = _view.CreateBulltObject();
            SpawnBullet(bullet);
        }

        for (int i = 0; i < _model.amountToPool; i++)
        {
            Debug.Log(_model.amountToPool);
        }
    }

    private void SpawnBullet(GameObject bullet)
    {
        _model.AddBullet(bullet);
        //Debug.Log(_model.amountToPool);
        bullet.SetActive(true);
    }

    private void OnBulletMove()
    {
        Vector3 position = _model.Position + (Vector3.up * _model.ShootSpeed * Time.deltaTime);
        _model.SetPosition(position);
    }
}
