using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class BulletModel : BaseModel,IBulletModel
{
    public float ShootSpeed { get; set; } = 3f;

    public Vector3 BulletPosition { get; set; } = new Vector3();

    public void SetPosition(Vector3 position)
    {
        BulletPosition = position;
        SetDataAsDirty();
    }

    public BulletModel()
    {

    }
}
