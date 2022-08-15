using System.Collections;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
public interface IBulletModel : IBaseModel
{
    public Vector3 BulletPosition { get; }
    public float ShootSpeed { get; }
}