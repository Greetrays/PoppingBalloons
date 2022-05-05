using TMPro;
using UnityEngine;

public class RecordItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _score;

    public int Score { get; private set; }
    public string Name => _name.text;

    public void RefreshScore(int score)
    {
        Score = score;
        _score.text = Score.ToString();
    }

    public void Render(string name, int score)
    {
        RefreshScore(score);
        _name.text = name;
    }    
}
