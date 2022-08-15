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
    private BulletPoolController _bulletPool;
    private BulletController _bullet;

    protected override IConnector[] GetSceneConnectors()
    {
        return new IConnector[]
        {
            new SpaceConnector(),
            new BulletConnector(),
            new BulletPoolConnector()
        };
    }

    protected override IController[] GetSceneDependencies()
    {
        return new IController[]
        {
            new SpaceController(),
            new BulletPoolController(),
            new BulletController(),
            new InputSystemController()
        };
    }

    protected override IEnumerator InitSceneObject()
    {
        _space.SetView(_view.SpaceView);
        _bulletPool.SetView(_view.BulletPoolView);
        //_bullet.SetView(_view.BulletView);
        yield return null;
    }

    protected override IEnumerator LaunchScene()
    {
        yield return null;
    }

}
