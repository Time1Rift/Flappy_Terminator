using UnityEngine;

public class SpawnerBullets : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private bool _isBulletsPlayer;
    
    private void Awake()
    {
        Initializ(_template);

        foreach (var item in Pool)
            item.GetComponent<Bullet>().Init(_isBulletsPlayer);
    }

    public void Shoot(Transform shootPoint, Vector3 direction, bool isRotated)
    {
        if (TryGetObject(out GameObject bullet))
        {
            bullet.transform.position = shootPoint.position;
            bullet.GetComponent<Bullet>().ChangedDirection(direction, isRotated);
            bullet.SetActive(true);
        }
    }
}