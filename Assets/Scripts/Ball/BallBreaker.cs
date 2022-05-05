using UnityEngine;

public class BallBreaker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out DisableCollider disableObject))
        {
            gameObject.SetActive(false);
        }
    }
}
