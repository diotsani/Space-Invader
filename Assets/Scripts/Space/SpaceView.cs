using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class SpaceView : ObjectView<ISpaceModel>
{
    //[SerializeField] private GameObject _space;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _speed;
    protected override void InitRenderModel(ISpaceModel model)
    {
    }

    protected override void UpdateRenderModel(ISpaceModel model)
    {
        _direction = model.DirectMove; 
    }

    private void Update()
    {
        transform.Translate(_direction * _speed*Time.deltaTime);
    }
}
