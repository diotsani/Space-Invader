using Agate.MVC.Base;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUpController : ObjectController<PowerUpController, PowerUpModel, IPowerUpModel, PowerUpView>
{
    BulletPoolController _bulletPool;

    public void Init(PowerUpModel model, PowerUpView view) //Instance multiple onject
    {
        _model = model;
        SetView(view);
    }
    public void OnMovePowerUp()
    {
        _view.SetCallbacks(MovePowerUp, HitPlayer, EndPowerUp);
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

        if (_model.PowerUpPosition.y <= -5.5f)
        {
            PowerUpPosition();
            _view.gameObject.SetActive(false);
        }
    }

    public void HitPlayer()
    {
        Publish<OnPowerUpMessage>(new OnPowerUpMessage());
        // +5 durasi _model.float durasi
        //_model.DurationPU += 5;
        //Debug.Log(_model.DurationPU);
        _view.gameObject.SetActive(false);
    }

    public void EndPowerUp()
    {
        // + Durasi eror karena setiap powerup ter update, need fix

        if (_bulletPool.Model.IsPowerUp == true)
        {
            _model.Timer += Time.deltaTime;
            //Debug.Log(_model.Timer);
            if (_model.Timer >= _model.DurationPU)
            {
                _model.Timer = 0;
                Publish<OffPowerUpMessage>(new OffPowerUpMessage());
            }
        }
    }
}
