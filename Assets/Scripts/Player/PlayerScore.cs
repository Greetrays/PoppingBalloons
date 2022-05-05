using UnityEngine;
using UnityEngine.Events;

public class PlayerScore : MonoBehaviour
{
    public event UnityAction<int> Changed;

    public int Score { get; private set; }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector3.forward * 10);

            if (hit.collider == null)
                return;

            if (hit.collider.TryGetComponent(out Ball ball))
            {
                ball.Disable();
                Score++;
                Changed?.Invoke(Score);
            }
        }
    }

    public void Restart()
    {
        Score = 0;
        Changed?.Invoke(Score);
    }
}
