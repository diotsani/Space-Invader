using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using UnityEngine.Events;

public class BulletPoolView : ObjectView<IBulletPoolModel>
{
    [SerializeField] public GameObject bulletPrefab;

    protected override void InitRenderModel(IBulletPoolModel model)
    {
        transform.position = model.Position;
    }

    protected override void UpdateRenderModel(IBulletPoolModel model)
    {
        transform.position = model.Position;
    }
}
