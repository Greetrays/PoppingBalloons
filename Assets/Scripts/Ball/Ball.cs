using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Ball : MonoBehaviour
{
    [SerializeField] private float _minScale;
    [SerializeField] private float _maxScale;
    [SerializeField] private ParticleSystem _boomParticle;

    private SpriteRenderer _spriteRenderer;
    private float _scale;

    private void Start()
    {
        _scale = Random.Range(_minScale, _maxScale);
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        transform.localScale = new Vector2(_scale, _scale);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
        var particle = Instantiate(_boomParticle, transform.position, _boomParticle.transform.rotation);
        particle.startColor = _spriteRenderer.color;
    }
}
