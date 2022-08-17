using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class PowerUpPoolConnector : BaseConnector
{
    private PowerUpPoolController _powerUpPool;
    protected override void Connect()
    {
        Subscribe<StartPlayMessage>(_powerUpPool.OnInitPoolPU);
    }

    protected override void Disconnect()
    {
        Unsubscribe<StartPlayMessage>(_powerUpPool.OnInitPoolPU);
    }
}
