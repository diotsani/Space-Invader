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
        Subscribe<StartPlayMessage>(_bulletPool.OnBulletMove);
        Subscribe<StartPlayMessage>(_bullet.OnBulletMove);
    }

    protected override void Disconnect()
    {
        Unsubscribe<StartPlayMessage>(_bulletPool.InitPoolBullet);
        Unsubscribe<StartPlayMessage>(_bulletPool.OnBulletMove);
        Unsubscribe<StartPlayMessage>(_bullet.OnBulletMove);
    }
}