using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public abstract class SceneLauncher<TLauncher, TView> : BaseLauncher<TLauncher, TView>
    where TLauncher : SceneLauncher<TLauncher, TView>
    where TView : BaseSceneView
{
    protected override ILoad GetLoader()
    {
        return SceneLoader.Instance;
    }

    protected override IMain GetMain()
    {
        return GameMain.Instance;
    }

    protected override ISplash GetSplash()
    {
        return SplashScreen.Instance;
    }
}
