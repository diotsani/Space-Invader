using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MoveSpaceMassage
{
    public Vector2 direction { get; set; }

    public MoveSpaceMassage(Vector2 dir)
    {
        direction = dir;
    }
}
