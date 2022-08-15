using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public interface ISpaceModel : IBaseModel
{
    //public string Name { get; }

    public Vector2 DirectMove { get; set; }

    public float speed { get; set; }

    public Vector3 Position { get; set; }
}
