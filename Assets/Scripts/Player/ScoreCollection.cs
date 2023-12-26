using System;
using UnityEngine;

public class ScoreCollection : MonoBehaviour
{
    [SerializeField]private int _lengthBetweenGettingPoints = 2;

    private float _distanceGettingPoints;
    private int _score = 0;

    public event Action<int> ScoreChanged;

    private void Start()
    {
        _distanceGettingPoints = transform.position.x + _lengthBetweenGettingPoints;
    }

    private void Update()
    {
        if(transform.position.x >= _distanceGettingPoints)
        {
            AddScore();
            _distanceGettingPoints += _lengthBetweenGettingPoints;
        }
    }

    public void AddScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Restart()
    {
        _score = 0;
        _distanceGettingPoints = 0;
        ScoreChanged?.Invoke(_score);
    }
}