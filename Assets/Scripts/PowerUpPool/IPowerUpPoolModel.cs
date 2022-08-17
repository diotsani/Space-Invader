using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public interface IPowerUpPoolModel : IBaseModel
{
    public Vector3 PositionPU { get; }

    public float SpeedPU { get; }

    public int maxPowerUp { get; }

    public List<GameObject> pooledPowerUps { get; }
    public List<PowerUpController> powerUpControllers{ get; }
}
