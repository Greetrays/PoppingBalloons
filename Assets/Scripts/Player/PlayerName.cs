using UnityEngine;
using TMPro;

public class PlayerName : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputName;

    public string Name { get; private set; }

    public void SetName(string name)
    {
        Name = name;
    }
}
