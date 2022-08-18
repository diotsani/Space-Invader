using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using UnityEngine.Events;
using System;

public class EnemyPoolView : ObjectView<IEnemyPoolModel>
{
    [SerializeField] public GameObject enemyPrefab;
    UnityAction _onSpawnEnemy;
    UnityAction _onEnemyMove;
    protected override void InitRenderModel(IEnemyPoolModel model)
    {
        transform.position = model.EnemyPosition;
    }

    protected override void UpdateRenderModel(IEnemyPoolModel model)
    {
        transform.position = model.EnemyPosition;
    }
    public void SetCallbacks(UnityAction onSpawnEnemy, UnityAction onEnemyMove)
    {
        _onSpawnEnemy = onSpawnEnemy;
        _onEnemyMove = onEnemyMove;
    }
    private void Update()
    {
        _onSpawnEnemy?.Invoke();
        _onEnemyMove?.Invoke();
    }
}
