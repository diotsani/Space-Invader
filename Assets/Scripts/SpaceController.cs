using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class SpaceController : ObjectController<SpaceController, SpaceModel, ISpaceModel, SpaceView>
{

    float movSpeed = 4f;
    public void OnMoveSpace()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 direction = new Vector2(horizontalInput, 0).normalized;

        _view.transform.Translate(direction * movSpeed * Time.deltaTime);
    }

}
