using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using Agate.MVC.Core;
using UnityEngine.Events;
using UnityEngine;

public class BulletView : ObjectView<IBulletModel>
{
    private UnityAction _onMoveBullet;

    protected override void InitRenderModel(IBulletModel model)
    {
        transform.position = model.BulletPosition;
    }

    protected override void UpdateRenderModel(IBulletModel model)
    {
        transform.position = model.BulletPosition;
    }

    public void SetCallbacks(UnityAction onMoveBullet)
    {
        _onMoveBullet = onMoveBullet;

        Debug.Log("_onmove");
    }

    public void Update()
    {
        //Debug.Log(transform.position);
        //Debug.Log("update bullet view");
    }

    private void FixedUpdate()
    {
        Debug.Log(_onMoveBullet);
        _onMoveBullet?.Invoke();
    }
}
