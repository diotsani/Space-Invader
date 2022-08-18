using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class EnemyPoolController : ObjectController<EnemyPoolController, EnemyPoolModel,IEnemyPoolModel,EnemyPoolView>
{
    Vector3 direction = Vector3.right;
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
        for (int j = 0; j < _model.Rows; j++)
        {
            float width = 2f * (_model.Columns - 1);
            float height = -1f * (_model.Rows - 1);
            Vector2 centerOffset = new Vector2(-width * 0.5f, -height * 0.5f);
            Vector3 rowPosition = new Vector3(centerOffset.x, (1.5f * j) + centerOffset.y, 0f);
            for (int k = 0; k < _model.Columns; k++)
            {
                EnemyModel instanceEnemy = new EnemyModel();
                GameObject enemy = GameObject.Instantiate(_view.enemyPrefab, _view.transform);
                AddEnemyList(enemy); // Add Enemy Object To List
                EnemyView instanceEnemyView = enemy.GetComponent<EnemyView>();
                EnemyController instance = new EnemyController();
                InjectDependencies(instance);
                AddEnemyControlList(instance); // Add Enemy Controller To List
                instance.Init(instanceEnemy, instanceEnemyView);

                // Calculate and set the position of the enemy in the row
                Vector3 position = rowPosition;
                position.x += 2f * k;
                enemy.gameObject.transform.localPosition = position;
            }
        }
    }

    public void OnInitPoolEnemy()
    {
        _view.SetCallbacks(InitPoolEnemy,EnemyMove);
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

    public void OnEnemyKill(EnemyDespawnMessage message) // Int Enemy Killed +1
    {
        _model.EnemyKilled += 1;
    }

    public void AddEnemyList(GameObject enemy)
    {
        _model.AddEnemys(enemy);
    }

    public void AddEnemyControlList(EnemyController enemyC)
    {
        _model.AddEnemyControls(enemyC);
    }

    // Move ------------------------------------------------------------------
    public void EnemyMove()
    {
        Vector3 position = _model.EnemyPosition + (direction * _model.EnemySpeed * Time.deltaTime);
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
        if (direction == Vector3.right && _view.transform.position.x >= (rightEdge.x - 4f))
        {
            ChangeMove();
        }
        else if (direction == Vector3.left && _view.transform.position.x <= (leftEdge.x + 4f))
        {
            ChangeMove();
        }
        _model.SetPosition(position);
    }
    public void ChangeMove()
    {
        direction = new Vector3(-direction.x, direction.y*-1f, 0f);
        Vector3 directY = new Vector3(_model.EnemyPosition.x, -1);
        Vector3 position = _view.transform.position;
        position.y -= 1f;
        _view.transform.position = position;
        _model.SetPosition(position);
    }
}
