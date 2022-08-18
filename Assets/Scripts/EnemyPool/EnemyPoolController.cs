using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class EnemyPoolController : ObjectController<EnemyPoolController, EnemyPoolModel,EnemyPoolView>
{
    public override IEnumerator Finalize()
    {
        yield return base.Finalize();
    }
    public override void SetView(EnemyPoolView view)
    {
        base.SetView(view);
        InstantiateEnemy();
        OnInitPoolEnemy();
    }
    public void InstantiateEnemy()
    {
        //for (int i = 0; i < _model.MaxEnemy; i++)
        //{
            for (int j = 0;j < _model.Rows; j++)
            {
                float width = 1.5f * (_model.Columns - 1);
                float height = -1f * (_model.Rows - 1);

                Vector2 centerOffset = new Vector2(-width * 0.5f, -height * 0.5f);
                Vector3 rowPosition = new Vector3(centerOffset.x, (1.5f * j) + centerOffset.y, 0f);

                for (int k = 0; k < _model.Columns; k++)
                {
                    EnemyModel instanceEnemy = new EnemyModel();
                    GameObject enemy = GameObject.Instantiate(_view.enemyPrefab, _view.transform);
                    AddEnemyList(enemy);

                    EnemyView instanceEnemyView = enemy.GetComponent<EnemyView>();
                    EnemyController instance = new EnemyController();
                    InjectDependencies(instance);
                    AddEnemyControlList(instance);

                    instance.Init(instanceEnemy, instanceEnemyView);


                    // Calculate and set the position of the enemy in the row
                    Vector3 position = rowPosition;
                    position.x += 1.5f * k;
                    enemy.gameObject.transform.localPosition = position;

                    //enemy.gameObject.SetActive(false);
                }
            }
        //}
    }

    public void OnInitPoolEnemy()
    {
        _view.SetCallbacks(InitPoolEnemy);
    }

    public void InitPoolEnemy()
    {
        if(_model.EnemyKilled >= _model.MaxEnemy)
        {
            _model.Timer += Time.deltaTime;
            if (_model.Timer >= _model.DurationSpawn)
            {
                for (int i = 0; i < _model.MaxEnemy; i++)
                {
                    SpawnEnemyPool();
                    _model.EnemyKilled = 0;
                    _model.Timer = 0;
                }
            }
        }
    }

    public void SpawnEnemyPool()
    {
        GameObject enemyPool = PoolEnemy();
        if (enemyPool != null)
        {
            enemyPool.SetActive(true);
        }
    }

    public GameObject PoolEnemy()
    {
        for (int i = 0; i < _model.MaxEnemy; i++)
        {
            //Debug.Log(_model.amountToPool);
            if (!_model.PooledEnemys[i].activeInHierarchy)
            {
                //_model.powerUpControllers[i].PowerUpPosition();
                return _model.PooledEnemys[i];
            }
        }
        return null;
    }

    public void OnEnemyKill(EnemyDespawnMessage message)
    {
        //GameObject enemys = DespawnEnemy();
        _model.EnemyKilled += 1;

        //if (enemys == null) // Jika semua musuh tidak aktif di hieraki maka musuh spawn ulang
        //{
            //Debug.Log(_model.PooledEnemys.Count);
            //OnInitPoolEnemy();
        //}
    }

    public GameObject DespawnEnemy()
    {
        for (int i = 0; i < _model.MaxEnemy; i++)
        {
            if (_model.PooledEnemys[i].activeInHierarchy)
            {
                return _model.PooledEnemys[i];
            }
        }
        return null;
    }

    public void AddEnemyList(GameObject enemy)
    {
        _model.AddEnemys(enemy);
    }

    public void AddEnemyControlList(EnemyController enemyC)
    {
        _model.AddEnemyControls(enemyC);
    }

    public void RemoveEnemyList(GameObject enemyList)
    {
        _model.RemoveEnemys(enemyList);
    }
}
