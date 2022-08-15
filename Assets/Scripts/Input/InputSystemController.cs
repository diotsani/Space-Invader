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
        _inputSystemManager.Space.Shoot.performed += OnShoot;
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        Publish<StartPlayMessage>(new StartPlayMessage());

        Debug.Log(context);
    }

    private void OnTap(InputAction.CallbackContext context)
    {
        //Publish<MoveSpaceMassage>(new MoveSpaceMessage());

        Publish(new MoveSpaceMessage(context.ReadValue<Vector2>()));
    }
}
