using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public interface  IEnemyModel : IBaseModel
{
    public Vector3 pos { get; }
}
