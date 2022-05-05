using TMPro;
using UnityEngine;

public class GameOverPanel : Window
{
    [SerializeField] private TMP_Text _score;

    public void ShowResult(string name, int score)
    {
        _score.text = $"{name} заработал {score} очков!";
        Open();
    }
}
