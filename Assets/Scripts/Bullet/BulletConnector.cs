using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class BulletConnector : BaseConnector
{
    private BulletController _bullet;
    protected override void Connect()
    {
        //Subscribe<MoveBulletMessage>(_bullet.OnBulletMove);
    }

    protected override void Disconnect()
    {
        //Unsubscribe<MoveBulletMessage>(_bullet.OnBulletMove);
    }
}
