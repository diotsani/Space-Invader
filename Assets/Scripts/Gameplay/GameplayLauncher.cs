using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;
using System;

public class GameplayLauncher : SceneLauncher<GameplayLauncher,GameplayView>
{
    public override string SceneName => "Gameplay";

    private SpaceController _space;

    protected override IConnector[] GetSceneConnectors()
    {
        return new IConnector[]
        {
            new SpaceConnector(),
        };
    }

    protected override IController[] GetSceneDependencies()
    {
        return new IController[]
        {
            new SpaceController(),
            new InputSystemController()
        };
    }

    protected override IEnumerator InitSceneObject()
    {
        _space.SetView(_view.SpaceView);
        yield return null;
    }

    protected override IEnumerator LaunchScene()
    {
        yield return null;
    }

}
