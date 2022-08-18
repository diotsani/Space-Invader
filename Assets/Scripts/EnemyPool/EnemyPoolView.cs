using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using UnityEngine.Events;
using System;

public class EnemyPoolView : BaseView
{
    [SerializeField] public GameObject enemyPrefab;
    UnityAction _onSpawnEnemy;
    public void SetCallbacks(UnityAction onSpawnEnemy)
    {
        _onSpawnEnemy = onSpawnEnemy;
    }
    private void Update()
    {
        _onSpawnEnemy?.Invoke();
    }
}
