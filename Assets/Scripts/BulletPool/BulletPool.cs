using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 15;

    [SerializeField] private GameObject bulletPrefab;

    private void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            pooledObjects.Add(bullet); 
        }
    }

    public GameObject GetPooledBullet()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            return pooledObjects[i];
        }

        return null;
    }
}
