using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class EnemyPoolModel : BaseModel
{
    public int Rows { get; set; } = 3;
    public int Columns { get; set; } = 5;
    public int MaxEnemy { get; set; } = 15;
    public int EnemyKilled { get; set; }
    public float Timer { get; set; }
    public float DurationSpawn { get; set; } = 2;

    public List<GameObject> PooledEnemys { get; set; } = new List<GameObject>();
    public List<EnemyController> EnemyControllers { get; set; } = new List<EnemyController>();
    public void AddEnemys(GameObject enemy)
    {
        PooledEnemys.Add(enemy);
        SetDataAsDirty();
    }
    public void RemoveEnemys(GameObject enemy)
    {
        PooledEnemys.Remove(enemy);
        SetDataAsDirty();
    }
    public void AddEnemyControls(EnemyController enemyControls)
    {
        EnemyControllers.Add(enemyControls);
        SetDataAsDirty();
    }
}
