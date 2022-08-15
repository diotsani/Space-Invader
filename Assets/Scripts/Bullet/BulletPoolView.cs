using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using UnityEngine.Events;

public class BulletPoolView : ObjectView<IBulletPoolModel>
{
    [SerializeField] private GameObject bulletPrefab;

    private UnityAction _onMoveBullet;

    public void SetCallbacks(UnityAction onMoveBullet)
    {
        _onMoveBullet = onMoveBullet;
    }

    protected override void InitRenderModel(IBulletPoolModel model)
    {
        transform.position = model.Position;
    }

    protected override void UpdateRenderModel(IBulletPoolModel model)
    {
        transform.position = model.Position;
    }

    public GameObject CreateBulltObject()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform);
        return bullet;
    }

    private void Update()
    {
        _onMoveBullet?.Invoke();
    }
}
