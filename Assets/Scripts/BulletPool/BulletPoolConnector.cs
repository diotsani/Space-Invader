using System.Collections;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class BulletPoolConnector : BaseConnector
{
    private BulletPoolController _bulletPool;
    private BulletController _bullet;
    protected override void Connect()
    {
        Subscribe<StartPlayMessage>(_bulletPool.InitPoolBullet);
        Subscribe<OnPowerUpMessage>(_bulletPool.SetIsPowerUp);
        Subscribe<OffPowerUpMessage>(_bulletPool.SetEndPowerUp);
        //Subscribe<StartPlayMessage>(_bulletPool.OnBulletMove);
        //Subscribe<MoveBulletMessage>(_bullet.OnBulletMove);
    }

    protected override void Disconnect()
    {
        Unsubscribe<StartPlayMessage>(_bulletPool.InitPoolBullet);
        Unsubscribe<OnPowerUpMessage>(_bulletPool.SetIsPowerUp);
        Unsubscribe<OffPowerUpMessage>(_bulletPool.SetEndPowerUp);
        //Unsubscribe<StartPlayMessage>(_bulletPool.OnBulletMove);
        //Unsubscribe<MoveBulletMessage>(_bullet.OnBulletMove);
    }
}