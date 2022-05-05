using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerScore))]
[RequireComponent(typeof(PlayerName))]

public class Player : MonoBehaviour
{
    [SerializeField] private DisableCollider _disableCollider;

    public event UnityAction<string, int> Died;
  
    private PlayerName _playerName;
    private PlayerScore _playerScore;

    private void OnEnable()
    {
        _disableCollider.BallTriggerEnter += OnBallTriggerEnter;
    }

    private void Start()
    {
        _playerName = GetComponent<PlayerName>();
        _playerScore = GetComponent<PlayerScore>();
    }

    private void OnDisable()
    {
        _disableCollider.BallTriggerEnter -= OnBallTriggerEnter;
    }

    private void OnBallTriggerEnter()
    {
        Died?.Invoke(_playerName.Name, _playerScore.Score);
        _playerScore.Restart();
    }
}
