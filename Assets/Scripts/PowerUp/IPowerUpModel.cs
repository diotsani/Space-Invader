using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public interface IPowerUpModel : IBaseModel
{
    public Vector3 PowerUpPosition { get; }
    public float SpeedPU { get; }

    public Vector3 spawnAreaMax { get; set; }
    public Vector3 spawnAreaMin { get; set; }
}
