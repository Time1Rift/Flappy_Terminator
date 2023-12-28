using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Spawners _spawners;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private TextMeshProUGUI _score;

    private void Start()
    {
        _player.gameObject.SetActive(false);
        _score.enabled = false;
        _startScreen.Open();
    }

    private void OnEnable()
    {
        _player.GameOver += OnGameOver;
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartGameButtonClick += OnRestartGameButtonClick;
    }

    private void OnDisable()
    {
        _player.GameOver -= OnGameOver;
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartGameButtonClick -= OnRestartGameButtonClick;
    }

    private void OnGameOver()
    {
        _score.enabled = false;
        Time.timeScale = 0;
        _spawners.StopWork();
        _gameOverScreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _score.enabled = true;
        _startScreen.Close();
        _player.Restart();
        _spawners.Restart();        
    }

    private void OnRestartGameButtonClick()
    {
        _gameOverScreen.Close();
        _player.gameObject.SetActive(false);
        _spawners.Restart();
        _startScreen.Open();
        Time.timeScale = 1;
    }
}