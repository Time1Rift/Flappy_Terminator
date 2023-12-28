using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T Prefab;

    [SerializeField] private Transform _container;

    private List<T> _pool = new();

    protected IEnumerable<T> Pool => _pool;

    public void Restart()
    {
        foreach (var item in _pool)
            item.gameObject.SetActive(false);
    }

    protected T GetObject(T prefab)
    {
        T result = _pool.FirstOrDefault(item => item.gameObject.activeSelf == false);

        if (result == null)
        {
            result = Instantiate(prefab, _container);
            result.gameObject.SetActive(false);
            _pool.Add(result);
        }

        return result;
    }

    protected T GetObject(List<T> prefab)
    {
        T result = _pool.FirstOrDefault(item => item.gameObject.activeSelf == false);

        if (result == null)
        {
            int index = Random.Range(0, prefab.Count);
            result = Instantiate(prefab[index], _container);
            result.gameObject.SetActive(false);
            _pool.Add(result);
        }

        return result;
    }
}