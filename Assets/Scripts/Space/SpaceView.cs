using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using UnityEngine.Events;

public class SpaceView : ObjectView<ISpaceModel>
{
    //[SerializeField] private GameObject _space;
    //[SerializeField] private Vector2 _direction;
    //[SerializeField] private float _speed;

    private UnityAction _onMovePosition;
    protected override void InitRenderModel(ISpaceModel model)
    {
        _model.Position = transform.position;
    }

    protected override void UpdateRenderModel(ISpaceModel model)
    {
        _model.Position = transform.position;
    }

    public void SetCallbacks(UnityAction OnMovePosition)
    {
        _onMovePosition = OnMovePosition;
    }

    private void FixedUpdate()
    {
        _onMovePosition?.Invoke();
    }

    private void Update()
    {
        //transform.Translate(_direction * _speed*Time.deltaTime);
    }
}
