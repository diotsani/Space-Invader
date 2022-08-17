using System.Collections;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections.Generic;

public interface IBulletPoolModel : IBaseModel
{
    public Vector3 Position { get;}

    public float ShootSpeed { get;}

    public int maxBullet { get; }

    public List<GameObject> pooledBullets { get;}
    public List<BulletController> bulletCtrs { get;}
}