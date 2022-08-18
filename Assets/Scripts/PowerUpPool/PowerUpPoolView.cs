using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using UnityEngine.Events;

public class PowerUpPoolView : ObjectView<IPowerUpPoolModel>
{
    [SerializeField] public GameObject powerUpPrefab;

    private UnityAction _onSpawnPowerUp;
    protected override void InitRenderModel(IPowerUpPoolModel model)
    {
        
    }

    protected override void UpdateRenderModel(IPowerUpPoolModel model)
    {
        
    }

    public void SetCallbacks(UnityAction onSpawnPowerUp)
    {
        _onSpawnPowerUp = onSpawnPowerUp;
    }

    private void Update()
    {
        _onSpawnPowerUp?.Invoke();
    }
}
