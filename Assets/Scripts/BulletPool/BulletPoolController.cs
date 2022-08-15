using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using System;

public class BulletPoolController : ObjectController<BulletPoolController,BulletPoolModel,IBulletPoolModel,BulletPoolView>
{

    SpaceController space;
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
            //GameObject bullet = _view.CreateBulltObject();
            BulletModel instanceBullet = new BulletModel();
            GameObject bullet = GameObject.Instantiate(_view.bulletPrefab, _view.transform);
            SpawnBullet(bullet);

            BulletView instanceViewBullet = bullet.GetComponent<BulletView>();
            BulletController instance = new BulletController();
          
            BulletConnector instanceConnector = new BulletConnector();
            InjectDependencies(instance);
            InjectDependencies(instanceConnector);
            instance.Init(instanceBullet, instanceViewBullet);

            Debug.Log(instance);

            instance.BulletPosition();
            instance.OnBulletMove(message);
        }

        for (int i = 0; i < _model.amountToPool; i++)
        {
            //Debug.Log(_model.amountToPool);
        }
    }
    private void SpawnBullet(GameObject bullet)
    {
        bullet.transform.position = space.Model.Position;
        _model.SpawnPoint();
        _model.AddBullet(bullet);
        bullet.SetActive(true);

        Debug.Log("Spawned Bullet");
    }

    public void OnBulletMove(StartPlayMessage message)
    {
        _view.SetCallbacks(BulletMove);
        //Debug.Log("Callback Bullet Move");
    }

    public void BulletMove()
    {
        //Debug.Log("Callback Bullet Move");
        //Vector3 position = Model.Position + (Vector3.up * _model.ShootSpeed * Time.deltaTime);
        //_model.SetPosition(position);
    }
}
