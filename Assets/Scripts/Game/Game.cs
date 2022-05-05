using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private GameplayPanel _gameplayPanel;
    [SerializeField] private RecordPanel _recordPanel;
    [SerializeField] private NameInputField _nameInputField;
    [SerializeField] private GameOverPanel _gameOverPanel;
    [SerializeField] private Pool _pool;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _nameInputField.NameChanged += Play;
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _nameInputField.NameChanged -= Play;
        _player.Died -= OnDied;
    }

    private void Start()
    {
        Restart();
    }

    public void Pause()
    {
        _pausePanel.Open();
        Time.timeScale = 0;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Continue()
    {
        _pausePanel.Close();
        Time.timeScale = 1;
    }

    private void Play()
    {
        Time.timeScale = 1;
        _gameplayPanel.Open();
    }

    private void Restart()
    {
        Time.timeScale = 0;
        _nameInputField.Open();
        _gameplayPanel.Close();
        _pausePanel.Close();
        _recordPanel.Close();
        _gameOverPanel.Close();
        _pool.Reset();
    }

    private void OnDied(string name, int score)
    {
        Time.timeScale = 0;
        _gameplayPanel.Close();
        _gameOverPanel.ShowResult(name, score);
    }    
}
