using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MoveSpaceMessage
{
    public Vector2 direction { get; set; }

    public MoveSpaceMessage(Vector2 dir)
    {
        direction = dir;
    }
}
