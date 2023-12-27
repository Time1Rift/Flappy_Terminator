using UnityEngine;

public class SpawnerBulletsVersion2 : ObjectPoolVersion2
{
    [SerializeField] private GameObject _bulletPrafab;
    [SerializeField] private bool _isBulletsPlayer;

    public void Shoot(Transform shootPoint, Vector3 direction, bool isRotated)
    {
        GameObject bullet = GetObject(_bulletPrafab);
        bullet.transform.position = shootPoint.position;
        bullet.GetComponent<Bullet>().ChangedDirection(direction, isRotated);
        bullet.SetActive(true);
    }

    protected override void InitObject(GameObject result)
    {
        base.InitObject(result);
        result.GetComponent<Bullet>().Init(_isBulletsPlayer);
    }
}