using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class GameplayLauncher : SceneLauncher<GameplayLauncher,GameplayView>
{
    public override string SceneName => "Gameplay";

    private SpaceController _space;

    protected override IConnector[] GetSceneConnectors()
    {
        return null;
    }

    protected override IController[] GetSceneDependencies()
    {
        return new IController[]
        {
            new SpaceController()
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
