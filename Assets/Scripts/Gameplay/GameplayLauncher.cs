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
    private PowerUpPoolController _powerUpPool;
    private EnemyPoolController _enemyPool;

    protected override IConnector[] GetSceneConnectors()
    {
        return new IConnector[]
        {
            new SpaceConnector(),
            new BulletPoolConnector(),
            new PowerUpPoolConnector(),
            new PowerUpPoolConnector()
        };
    }


    protected override IController[] GetSceneDependencies()
    {
        return new IController[]
        {
            new SpaceController(),
            new BulletPoolController(),
            new PowerUpPoolController(),
            new EnemyPoolController(),
            new InputSystemController()
        };
    }

    protected override IEnumerator InitSceneObject()
    {
        _space.SetView(_view.SpaceView);
        _bulletPool.SetView(_view.BulletPoolView);
        _powerUpPool.SetView(_view.PowerUpPoolView);
        _enemyPool.SetView(_view.EnemyPoolView);
        yield return null;
    }

    protected override IEnumerator LaunchScene()
    {
        yield return null;
    }

}
