using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;
    private Vector3 _direction = Vector3.right;

    public bool IsBelongsPlayer { get; private set; }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy) && IsBelongsPlayer == false)
            return;

        gameObject.SetActive(false);
    }

    public void Init(bool isBulletPlayer) => IsBelongsPlayer = isBulletPlayer;

    public void ChangedDirection(Vector3 direction, bool isRotated)
    {
        _spriteRenderer.flipX = isRotated;
        _direction = direction;
    }
}