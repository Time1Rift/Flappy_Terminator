using UnityEngine;

public class SpawnerBullets : ObjectPool<Bullet>
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private bool _isBulletsPlayer;
    
    public void Shoot(Transform shootPoint, Vector3 direction, bool isRotated)
    {
        Bullet bullet = GetObject(_bulletPrefab);
        bullet.Init(_isBulletsPlayer);
        bullet.transform.position = shootPoint.position;
        bullet.ChangedDirection(direction, isRotated);
        bullet.gameObject.SetActive(true);
    }
}