using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using UnityEngine.InputSystem;
using System;

public class InputSystemController : BaseController<InputSystemController>
{
    private InputSystemManager _inputSystemManager = new InputSystemManager();

    public override IEnumerator Initialize()
    {
        yield return base.Initialize();
        _inputSystemManager.Space.Enable();
        _inputSystemManager.Space.Tap.performed += OnTap;
    }

    private void OnTap(InputAction.CallbackContext context)
    {
        //Publish<MoveSpaceMassage>(new MoveSpaceMassage());

        Publish(new MoveSpaceMassage(context.ReadValue<Vector2>()));
    }
}
