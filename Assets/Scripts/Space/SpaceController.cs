using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class SpaceController : ObjectController<SpaceController, SpaceModel, ISpaceModel, SpaceView>
{
    public void MoveSpace(MoveSpaceMessage message)
    {
        _model.SetMoveDirection(message.direction);
        //Debug.Log(message.direction);


        //float horizontalInput = Input.GetAxis("Horizontal");
        //direct = new Vector2(horizontalInput, 0).normalized;
        

        //Vector2 direction = new Vector2(horizontalInput, 0).normalized;

        //_view.transform.Translate(direction * movSpeed * Time.deltaTime);
    }

    public void OnMoveSpace(MoveSpaceMessage message) //Call Method MovingSpace
    {
        _view.SetCallbacks(MovingSpace);
    }

    public void MovingSpace() // Move space with input
    {
        Vector3 posDefault = _view.transform.position;

        _view.transform.Translate(_model.DirectMove * _model.speed * Time.deltaTime);
        
        //Constraint Position
        if(_view.transform.position.x >= 8f)
        {
            _view.transform.position = new Vector3(8f, posDefault.y);
        }
        if (_view.transform.position.x <= -8f)
        {
            _view.transform.position = new Vector3(-8f, posDefault.y);
        }

        _model.Position = _view.transform.position;
    }
}
