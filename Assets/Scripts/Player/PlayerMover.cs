using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2.5f;
    [SerializeField] private float _tapForce = 4;
    [SerializeField] private float _rotationSpeed = 1;
    [SerializeField] private float _maxRotationZ = 35;
    [SerializeField] private float _minRotationZ = -60;
    [SerializeField] private Vector3 _startPosition = new Vector3(-1,0,0);

    private Rigidbody2D _rigidbody;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _maxRotation = Quaternion.Euler(0,0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0,0, _minRotationZ);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rigidbody.velocity = new Vector2(_speed, _tapForce);
            transform.rotation = _maxRotation;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Restart()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _rigidbody.velocity = Vector2.zero;
    }
}