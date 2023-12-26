using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    private List<ObjectPool> _pools = new();

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
            _pools.Add(transform.GetChild(i).GetComponent<ObjectPool>());
    }

    public void Restart()
    {
        foreach (ObjectPool pool in _pools)
            pool.Restart();
    }
}