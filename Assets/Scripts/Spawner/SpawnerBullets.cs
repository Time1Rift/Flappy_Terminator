using UnityEngine;

public class SpawnerBullets : ObjectPool<Bullet>
{
    [SerializeField] private bool _isBulletsPlayer;
    
    public void Shoot(Transform shootPoint, Vector3 direction, bool isRotated)
    {
        Bullet bullet = GetObject(Prefab);
        bullet.Init(_isBulletsPlayer);
        bullet.transform.position = shootPoint.position;
        bullet.GetComponent<Bullet>().ChangedDirection(direction, isRotated);
        bullet.gameObject.SetActive(true);
    }
}