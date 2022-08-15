using System.Collections;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class BulletPoolConnector : BaseConnector
{
    private BulletPoolController _bulletPool;
    protected override void Connect()
    {
        Subscribe<StartPlayMessage>(_bulletPool.InitPoolBullet);
    }

    protected override void Disconnect()
    {
        Unsubscribe<StartPlayMessage>(_bulletPool.InitPoolBullet);
    }
}