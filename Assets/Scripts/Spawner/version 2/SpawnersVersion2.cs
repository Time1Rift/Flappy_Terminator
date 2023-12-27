using System.Collections.Generic;
using UnityEngine;

public class SpawnersVersion2 : MonoBehaviour
{
    private List<ObjectPoolVersion2> _pools = new();

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
            _pools.Add(transform.GetChild(i).GetComponent<ObjectPoolVersion2>());
    }

    public void Restart()
    {
        foreach (ObjectPoolVersion2 pool in _pools)
            pool.Restart();
    }
}
