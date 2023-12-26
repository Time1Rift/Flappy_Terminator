using UnityEngine;

public class Enemy : MonoBehaviour, IInteractable
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet) && bullet.IsBelongsPlayer == false)
            return;

        gameObject.SetActive(false);
    }
}