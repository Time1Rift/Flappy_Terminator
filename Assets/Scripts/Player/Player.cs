using System;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent(typeof(PlayerMover), typeof(ScoreCollection), typeof(PlayerCollisionHandler))]
public class Player : MonoBehaviour
{
    private PlayerMover _mover;
    private ScoreCollection _score;
    private PlayerCollisionHandler _handler;

    public event Action GameOver;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _score = GetComponent<ScoreCollection>();
        _handler = GetComponent<PlayerCollisionHandler>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += OnCollisionDetected;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= OnCollisionDetected;
    }

    public void Restart()
    {
        gameObject.SetActive(true);
        _mover.Restart();
        _score.Restart();
    }

    private void OnCollisionDetected(IInteractable interactable)
    {
        if (interactable is Bullet)
            Die();
        else if (interactable is DeathZone)
            Die();
        else if (interactable is Enemy)
            Die();
    }

    private void Die()
    {
        GameOver?.Invoke();
    }
}