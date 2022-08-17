using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class BulletController : ObjectController<BulletController,BulletModel,IBulletModel,BulletView>
{
    SpaceController space;
    BulletPoolController bulletPool;

    public void Init(BulletModel model, BulletView view) //Instance multiple onject
    {
        _model = model;
        SetView(view);
    }

    public void OnBulletMove()
    {
        _view.SetCallbacks(BulletMove,HitEnemy);
        //Debug.Log("Callback OnBulletMove");
    }

    public void HitEnemy() // Hit Enemy terpanggil ketika bertabrakan dengan enemy, dipanggil menggunakan fungsi callbacks
    {
        _model.Health--;
        if(_model.Health == 0)
        {
            _view.gameObject.SetActive(false);
        }
        //Debug.Log("Hitting Enemy");
    }

    public void OnSpawn()
    {
        //Debug.Log("OnSpawn");
        _view.gameObject.SetActive(true);
    }

    private void BulletMove() // BulletMove terpanggil pada update view, dipanggil dengan callbacks
    {
        Vector3 position = _model.BulletPosition + (Vector3.up * _model.ShootSpeed * Time.deltaTime);
        _model.SetPosition(position);

        if(_model.BulletPosition.y >= 7)
        {
            BulletPosition();
            _view.gameObject.SetActive(false);
        }
    }

    public void BulletPosition() // BulletPostion, mengatur posisi bullet ketika terspawn berada di posisi pesawat
    {
        _model.Health=1;
        Vector3 pos = _model.BulletPosition = space.Model.Position;
        _model.SetPosition(pos);
    }

    public void OnHitPowerUp()
    {
        if(bulletPool.Model.IsPowerUp==true)
        {
            _view.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            _model.Health = 2;
        }

        if (bulletPool.Model.IsPowerUp == false)
        {
            _view.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            _model.Health = 1;
        }
    }
}
