using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class GameplayLauncher : SceneLauncher<GameplayLauncher,GameplayView>
{
    public override string SceneName => throw new System.NotImplementedException();

    private SpaceController _space;

    protected override ILoad GetLoader()
    {
        throw new System.NotImplementedException();
    }

    protected override IMain GetMain()
    {
        throw new System.NotImplementedException();
    }

    protected override IConnector[] GetSceneConnectors()
    {
        throw new System.NotImplementedException();
    }

    protected override IController[] GetSceneDependencies()
    {
        return new IController[]
        {
            new SpaceController()
        };
    }

    protected override ISplash GetSplash()
    {
        throw new System.NotImplementedException();
    }

    protected override IEnumerator InitSceneObject()
    {
        _space.SetView(_view.SpaceView);
        yield return null;
    }

    protected override IEnumerator LaunchScene()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
