using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public interface IEnemyPoolModel : IBaseModel
{
    public Vector3 EnemyPosition { get;}
}
