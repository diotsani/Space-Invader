using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class BulletConnector : BaseConnector
{
    private BulletController _bullet;

    protected override void Connect()
    { Debug.Log(_bullet);
        Subscribe<StartPlayMessage>(_bullet.OnBulletMove);
       
    }

    protected override void Disconnect()
    {
        Unsubscribe<StartPlayMessage>(_bullet.OnBulletMove);
    }
}
