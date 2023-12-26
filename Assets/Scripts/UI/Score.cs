using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private ScoreCollection _scoreCollection;
    [SerializeField] private TextMeshProUGUI _score;

    private void OnEnable()
    {
        _scoreCollection.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _scoreCollection.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score) => _score.text = score.ToString();
}