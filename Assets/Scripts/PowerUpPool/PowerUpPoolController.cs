using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class PowerUpPoolController : ObjectController<PowerUpPoolController,PowerUpPoolModel,IPowerUpPoolModel,PowerUpPoolView>
{
    //float timer;
    public override IEnumerator Finalize()
    {
        yield return base.Finalize();
    }
    public override void SetView(PowerUpPoolView view)
    {
        base.SetView(view);
        InstantiatePU();
        OnInitPoolPU();
        //InstantiatePU();
    }

    public void InstantiatePU()
    {
        for (int i = 0; i < _model.maxPowerUp; i++)
        {
            PowerUpModel instancePU = new PowerUpModel();
            GameObject powerUp = GameObject.Instantiate(_view.powerUpPrefab, _view.transform);
            OnInitPU(powerUp);

            PowerUpView instancePowerUpView = powerUp.GetComponent<PowerUpView>();
            PowerUpController instance = new PowerUpController();

            //PowerUpConnector instanceConnector = new PowerUpConnector();
            InjectDependencies(instance);
            //InjectDependencies(instanceConnector);

            AddPUController(instance); // add pu controller to list

            instance.Init(instancePU, instancePowerUpView);

            instance.PowerUpPosition();
            instance.OnMovePowerUp();

            powerUp.gameObject.SetActive(false);
        }
    }

    public void OnInitPoolPU()
    {
        _view.SetCallbacks(InitPoolPU);
    }
    public void InitPoolPU()
    {
        float spawnInterval = 5;
        _model.timer += Time.deltaTime;

        if(_model.timer >= spawnInterval)
        {
            SpawnPowerUpPool();
            //Debug.Log("Spawn Power 5");
            _model.timer -= spawnInterval;
        }
    }

    public void SpawnPowerUpPool()
    {
        GameObject powerUpPool = PoolPowerUp();
        if (powerUpPool != null)
        {
            powerUpPool.SetActive(true);
        }
    }

    public GameObject PoolPowerUp()
    {
        for (int i = 0; i < _model.maxPowerUp; i++)
        {
            //Debug.Log(_model.amountToPool);
            if (!_model.pooledPowerUps[i].activeInHierarchy)
            {
                _model.powerUpControllers[i].PowerUpPosition();
                return _model.pooledPowerUps[i];
            }
        }
        return null;
    }

    public void OnInitPU(GameObject powerUp)
    {
        _model.AddPU(powerUp);
    }

    public void AddPUController(PowerUpController pu)
    {
        _model.AddPowerUpControls(pu);
    }
}
