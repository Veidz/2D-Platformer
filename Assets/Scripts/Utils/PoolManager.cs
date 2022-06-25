using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject prefab;
    public List<GameObject> pooledObjects;

    public int amount = 20;

    private void Awake()
    {
        StartPool();
    }

    private void StartPool()
    {
        pooledObjects = new List<GameObject>();

        for (int index = 0; index < amount; index += 1)
        {
            var obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int index = 0; index < amount; index += 1)
        {
            if (!pooledObjects[index].activeInHierarchy)
            {
                return pooledObjects[index];
            }
        }

        return null;
    }
}
