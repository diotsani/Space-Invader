using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class BulletController : ObjectController<BulletController,BulletModel,IBulletModel,BulletView>
{
    public override IEnumerator Finalize()
    {
        yield return base.Finalize();
    }

    public override void SetView(BulletView view)
    {
        base.SetView(view);
        Debug.Log(view);
    }

    public void OnBulletMove(StartPlayMessage message)
    {
        _view.SetCallbacks(BulletMove);
        Debug.Log("Callback OnBulletMove");
    }

    public void BulletMove()
    {
        Vector3 position = _model.BulletPosition + (Vector3.up * _model.ShootSpeed * Time.deltaTime);
        _model.SetPosition(position);
    }
}
