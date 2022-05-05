using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RecordPanel : Window
{
    [SerializeField] private Transform _container;
    [SerializeField] private RecordItem _template;
    [SerializeField] private Player _player;

    private List<RecordItem> _recordItems = new List<RecordItem>();

    private void OnEnable()
    {
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
    }

    private void OnDied(string name, int score)
    {
        if (CheckForMatch(name, score))
        {
            RecordItem newItem = Instantiate(_template, _container);
            newItem.Render(name, score);
            _recordItems.Add(newItem);
        }

        Sort();
    }

    private bool CheckForMatch(string nameNewItem, int score)
    {
        foreach (var item in _recordItems)
        {
            if (item.Name == nameNewItem)
            {
                if (item.Score < score)
                {
                    item.RefreshScore(score);
                }

                return false;
            }
        }

        return true;
    }

    private void Sort()
    {
        var sortItems = _recordItems.OrderByDescending(item => item.Score).ToList();
        _recordItems = sortItems;

        foreach (var item in _recordItems)
        {
            item.transform.parent = null;
            item.transform.parent = _container;
        }
    }
}
