using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class SpaceModel : BaseModel, ISpaceModel
{
    //public string Name => throw new System.NotImplementedException();

    public Vector2 DirectMove { get; set; }
    public float speed { get; set; }

    public void SetMoveDirection(Vector2 directMove)
    {
        DirectMove = directMove;
        SetDataAsDirty();
    }

}
