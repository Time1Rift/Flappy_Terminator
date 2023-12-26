using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capasity;

    private List<GameObject> _pool = new();

    protected IEnumerable<GameObject> Pool => _pool;

    public void Restart()
    {
        foreach (var item in _pool)
            item.SetActive(false);
    }

    protected void Initializ(GameObject prefab)
    {
        for (int i = 0; i < _capasity; i++)
        {
            GameObject newObject = Instantiate(prefab, _container);
            newObject.SetActive(false);
            _pool.Add(newObject);
        }
    }

    protected bool TryGetObject(out GameObject result )
    {
        result = _pool.FirstOrDefault(item => item.activeSelf == false);
        return result != null;
    }
}