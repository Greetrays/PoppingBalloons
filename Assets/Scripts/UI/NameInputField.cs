using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class NameInputField : Window
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private PlayerName _playerName;

    public event UnityAction NameChanged;

    public void TrySetName()
    {
        if (_inputField.text != "")
        {
            _playerName.SetName(_inputField.text);
            NameChanged?.Invoke();
            Close();
        }
    }
}
