using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class BulletController : ObjectController<BulletController,BulletModel,IBulletModel,BulletView>
{
    SpaceController space;

    public void Init(BulletModel model, BulletView view)
    {
        _model = model;
        SetView(view);
    }

    public void OnBulletMove(StartPlayMessage message)
    {
        _view.SetCallbacks(BulletMove);
        Debug.Log("Callback OnBulletMove");
    }

    private void BulletMove()
    {
        Vector3 position = _model.BulletPosition + (Vector3.up * _model.ShootSpeed * Time.deltaTime);
        _model.SetPosition(position);
    }

    public void BulletPosition()
    {
        Vector3 pos = _model.BulletPosition = space.Model.Position;
        _model.SetPosition(pos);
    }
}
