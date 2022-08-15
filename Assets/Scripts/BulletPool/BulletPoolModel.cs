using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

public class BulletPoolModel : BaseModel,IBulletPoolModel
{
    public int amountToPool { get; set; } = 3;
    public int maxBullet { get; set; } = 15;

    public Vector3 Position { get; set; } //= new Vector3(0, 2, 0);
    public float ShootSpeed { get; set; } = 2f;

    public List<GameObject> pooledBullets { get; set; } = new List<GameObject>();
    public Vector3 SpawnPos { get; set; } = new Vector3();

    public void SpawnPoint()
    {
        //SpawnPos += space.Position;
        //SetDataAsDirty();
    }

    public void SetPosition(Vector3 position)
    {
        Position = position;
        SetDataAsDirty();
    }

    public void AddBullet(GameObject bullet)
    {
        pooledBullets.Add(bullet);
        SetDataAsDirty();
    }

    public void RemoveBullet(GameObject bullet)
    {
        pooledBullets.Remove(bullet);
        SetDataAsDirty();
    }

    public GameObject GetBullet()
    {
        for (int i = 0; i < pooledBullets.Count; i++)
        {
                return pooledBullets[i];
        }
        return null;

    }
}
