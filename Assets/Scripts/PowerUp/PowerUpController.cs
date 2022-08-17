using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using Agate.MVC.Base;
using Agate.MVC.Core;
using System;

public class PowerUpController : ObjectController<PowerUpController, PowerUpModel, IPowerUpModel, PowerUpView>
{
    BulletPoolController _bulletPool;
    float timer;

    public void Init(PowerUpModel model, PowerUpView view) //Instance multiple onject
    {
        _model = model;
        SetView(view);
    }
    public void OnMovePowerUp()
    {
        _view.SetCallbacks(MovePowerUp,HitPlayer,EndPowerUp);
    }

    public void PowerUpPosition() // random position on spawn / pooling
    {
        RandomPos(new Vector3(Random.Range(_model.spawnAreaMin.x, _model.spawnAreaMax.x), Random.Range(_model.spawnAreaMin.y, _model.spawnAreaMax.y), 0));
    }

    public void RandomPos(Vector3 posRnd)
    {
        if (posRnd.x < _model.spawnAreaMin.x || posRnd.x > _model.spawnAreaMax.x || posRnd.y < _model.spawnAreaMin.y || posRnd.y > _model.spawnAreaMax.y)
        {
            return;
        }
        Vector3 pos = _model.PowerUpPosition = new Vector3(posRnd.x, posRnd.y, 0);
        _model.SetPUPosition(pos);

    }
    public void MovePowerUp()
    {
        Vector3 pos = _model.PowerUpPosition + (Vector3.down * _model.SpeedPU * Time.deltaTime);
        _model.SetPUPosition(pos);

        if(_model.PowerUpPosition.y <= -5.5f)
        {
            PowerUpPosition();
            _view.gameObject.SetActive(false);
        }
    }

    public void HitPlayer()
    {
        Publish<OnPowerUpMessage>(new OnPowerUpMessage());
        _view.gameObject.SetActive(false);
    }

    public void EndPowerUp()
    {
        float powerUpDuration = 5f;

        if(_bulletPool.Model.IsPowerUp == true)
        {
            timer += Time.deltaTime;
            if (timer >= powerUpDuration)
            {
                Publish<OffPowerUpMessage>(new OffPowerUpMessage());
                Debug.Log("Power Up End");
                timer -= powerUpDuration;
            }
        }
    }
}
