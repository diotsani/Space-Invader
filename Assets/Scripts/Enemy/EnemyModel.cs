using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class EnemyModel : BaseModel, IEnemyModel
{
    public Vector3 pos { get; set; }

}
