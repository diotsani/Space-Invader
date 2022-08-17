using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using System;

public class PowerUpController : ObjectController<PowerUpController, PowerUpModel, IPowerUpModel, PowerUpView>
{

    public void Init(PowerUpModel model, PowerUpView view) //Instance multiple onject
    {
        _model = model;
        SetView(view);
    }

    public void PowerUpPosition()
    {

    }

    public void OnMovePowerUp()
    {

    }
}
