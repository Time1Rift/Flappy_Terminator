using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _secondsBetweenSpawn;

    private SpawnerBullets _spawnerBullets;
    private Coroutine _fire;
    private Vector3 _direction = Vector3.left;
    private bool _isRotated = false;

    private void OnEnable()
    {
        StopFire();
        _fire = StartCoroutine(Fire());
    }

    private void OnDisable()
    {
        StopFire();
    }

    public void Init(SpawnerBullets spawnerBullets) => _spawnerBullets = spawnerBullets;
    
    private void StopFire()
    {
        if (_fire != null)
            StopCoroutine(_fire);
    }

    private IEnumerator Fire()
    {
        WaitForSeconds wait = new WaitForSeconds(_secondsBetweenSpawn);
        
        while (enabled)
        {
            _spawnerBullets.Shoot(_shootPoint, _direction, _isRotated);
            yield return wait;
        }
    }
}