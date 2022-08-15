using System.Collections;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public interface IBulletPoolModel : IBaseModel
{
    public Vector3 Position { get;}

    public float ShootSpeed { get;}
}