using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class PowerUpPoolModel : BaseModel,IPowerUpPoolModel
{
    public Vector3 PositionPU { get; set; }
    public Vector3 SpawnPos { get; set; } = new Vector3();

    public float SpeedPU { get; set; } = 2f;

    public float timer { get; set; }

    public int maxPowerUp { get; set; } = 5;

    public List<GameObject> pooledPowerUps { get; set; } = new List<GameObject>();
    public List<PowerUpController> powerUpControllers { get; set; } = new List<PowerUpController>();

    public void SetPositionPU(Vector3 positionPU)
    {
        PositionPU = positionPU;
        SetDataAsDirty();
    }

    public void AddPU(GameObject powerUp)
    {
        pooledPowerUps.Add(powerUp);
        SetDataAsDirty();
    }

    public void RemovePowerUp(GameObject powerUp) // useless
    {
        pooledPowerUps.Remove(powerUp);
        SetDataAsDirty();
    }

    public void AddPowerUpControls(PowerUpController powerUp)
    {
        powerUpControllers.Add(powerUp);
        SetDataAsDirty();
    }
}
