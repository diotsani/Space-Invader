using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using UnityEngine.Events;

public class PowerUpView : ObjectView<IPowerUpModel>
{
    private UnityAction _onMovePU;
    private UnityAction _onHitPlayer;

    protected override void InitRenderModel(IPowerUpModel model)
    {
        transform.position = model.PowerUpPosition;
    }

    protected override void UpdateRenderModel(IPowerUpModel model)
    {
        transform.position = model.PowerUpPosition;
    }

    public void SetCallbacks(UnityAction onMovePU, UnityAction onHitPlayer)
    {
        _onMovePU = onMovePU;
        _onHitPlayer = onHitPlayer;
    }
    private void Update()
    {
        _onMovePU?.Invoke();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        bool isHitPlayer = collision.gameObject.CompareTag("Player");

        if (isHitPlayer)
        {
            _onHitPlayer?.Invoke();
        }
    }

}
