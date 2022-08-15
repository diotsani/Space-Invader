using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class SpaceConnector : BaseConnector
{
    private SpaceController _space;
    protected override void Connect()
    {
        Subscribe<MoveSpaceMessage>(_space.MoveSpace);
    }

    protected override void Disconnect()
    {
        Unsubscribe<MoveSpaceMessage>(_space.MoveSpace);
    }
}
