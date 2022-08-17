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
    public override void SetView(BulletPoolView view) //Init OnStart Scene
    {
        base.SetView(view);
        InstantiateBullet();
    }

    public void OnStartPlay(StartPlayMessage messege)
    {
        //_view.SetCallbacks(InitPoolBullet);
    }

    public void InstantiateBullet()
    {
        if (_model.pooledBullets.Count < _model.maxBullet)
        {
            for (int i = 0; i < _model.maxBullet; i++)
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

                AddBulletController(instance);

                instance.Init(instanceBullet, instanceViewBullet);

                //Debug.Log(instance);

                instance.BulletPosition();
                instance.OnBulletMove();

                bullet.gameObject.SetActive(false);
            }
        }
    }

    public void InitPoolBullet(StartPlayMessage message)
    {
        //_model.bulletCtrs[0].SpawnBulletPool();
        SpawnBulletPool();
    }

    public void SpawnBulletPool()
    {
        GameObject bulletPool = PoolBullet();
        if(bulletPool != null)
        {
            //bulletPool.transform.position = space.Model.Position;
            //_model.bulletCtrs[0].BulletPosition();
            bulletPool.SetActive(true);
            //Debug.Log("SpawnBulletPool");
        }
    }

    public GameObject PoolBullet()
    {
        for (int i = 0; i < _model.maxBullet; i++)
        {
            //Debug.Log(_model.amountToPool);
            if (!_model.pooledBullets[i].activeInHierarchy)
            {
                _model.bulletCtrs[i].BulletPosition();
                _model.bulletCtrs[i].OnHitPowerUp();
                //Debug.Log("PoolBullet");
                return _model.pooledBullets[i];
            }
        }
        return null;
    }
    private void SpawnBullet(GameObject bullet)
    {
        bullet.transform.position = space.Model.Position;
        _model.SpawnPoint();
        _model.AddBullet(bullet);
        bullet.SetActive(true);
        //Debug.Log("Spawned Bullet");
    }

    private void AddBulletController(BulletController bc)
    {
        _model.AddBulletControls(bc);
    }

    public void OnBulletMove(StartPlayMessage message)
    {
        _view.SetCallbacks(BulletMove);
        //Debug.Log("Callback Bullet Move");
    }

    public void BulletMove()
    {
        Debug.Log("Callback Bullet Move"); // Fungsi yang manggil harus dihapus
        //Vector3 position = Model.Position + (Vector3.up * _model.ShootSpeed * Time.deltaTime);
        //_model.SetPosition(position);
    }

    public void SetIsPowerUp(OnPowerUpMessage message)
    {
        _model.IsPowerUp = true;
    }

    public void SetEndPowerUp(OffPowerUpMessage messege)
    {
        _model.IsPowerUp = false;
    }
}
