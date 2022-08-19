using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class EnemyPoolModel : BaseModel,IEnemyPoolModel
{
    public int Rows { get; set; } = 3;
    public int Columns { get; set; } = 5;
    public int MaxEnemy { get; set; } = 15;
    public int EnemyKilled { get; set; }
    public float Timer { get; set; }
    public float DurationSpawn { get; set; } = 2f;
    public List<GameObject> PooledEnemys { get; set; } = new List<GameObject>();
    public List<EnemyController> EnemyControllers { get; set; } = new List<EnemyController>();
    public float EnemySpeed { get; set; } = 1f;//= 3f;

    public Vector3 EnemyPosition { get; set; } = new Vector3();

    public void SetPosition(Vector3 position)
    {
        EnemyPosition = position;
        SetDataAsDirty();
    }
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
