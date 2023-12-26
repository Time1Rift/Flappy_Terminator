using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private SpawnerBullets _spawnerBullets;
    [SerializeField] private Transform _shootPoint;

    private Vector3 _direction = Vector3.right;
    private bool _isRotated = true;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            _spawnerBullets.Shoot(_shootPoint, _direction, _isRotated);
    }
}