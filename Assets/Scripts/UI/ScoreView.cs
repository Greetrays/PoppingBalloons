using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private PlayerScore _playerScore;

    private TMP_Text _text;

    private void OnEnable()
    {
        _playerScore.Changed += OnChanged;
    }

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnDisable()
    {
        _playerScore.Changed -= OnChanged;
    }

    private void OnChanged(int score)
    {
        _text.text = score.ToString();
    }
}
