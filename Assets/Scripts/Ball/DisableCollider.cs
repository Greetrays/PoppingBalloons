using UnityEngine;
using UnityEngine.Events;

public class DisableCollider : MonoBehaviour
{
    public event UnityAction BallTriggerEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BallTriggerEnter?.Invoke();
    }
}
