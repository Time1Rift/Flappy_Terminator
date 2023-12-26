using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _xOffset = 1;

    private void Update()
    {
        Vector3 position = transform.position;
        position.x = _xOffset + _player.transform.position.x;
        transform.position = position;
    }
}