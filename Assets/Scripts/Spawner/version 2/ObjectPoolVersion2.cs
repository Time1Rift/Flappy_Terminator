using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoolVersion2 : MonoBehaviour
{
    [SerializeField] private Transform _container;

    private List<GameObject> _pool = new();

    protected IEnumerable<GameObject> Pool => _pool;

    public void Restart()
    {
        foreach (var item in _pool)
            item.SetActive(false);
    }

    protected GameObject GetObject(GameObject prefab)
    {
        GameObject result = _pool.FirstOrDefault(item => item.activeSelf == false);

        if (result == null)
        {
            result = Instantiate(prefab, _container);
            InitObject(result);
        }

        return result;
    }

    protected GameObject GetObject(List<GameObject> prefab)
    {
        GameObject result = _pool.FirstOrDefault(item => item.activeSelf == false);

        if (result == null)
        {
            int index = Random.Range(0, prefab.Count);
            result = Instantiate(prefab[index], _container);
            InitObject(result);
        }

        return result;
    }

    protected virtual void InitObject(GameObject result)
    {
        result.SetActive(false);
        _pool.Add(result);
    }
}