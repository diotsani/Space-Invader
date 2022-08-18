using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class EnemyController : ObjectController<EnemyController,EnemyModel,IEnemyModel,EnemyView>
{
    EnemyPoolController enemyPool;
    public void Init(EnemyModel model, EnemyView view)
    {
        _model = model;
        SetView(view);
    }
}
