using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Pool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private int _countObjects;
    [SerializeField] private float _delayBetweenSpawn;

    private float _elepsedTime;
    private float _minSpawnPosition;
    private float _maxSpawnPosition;

    private void Start()
    {
        Init(_countObjects, _template);
        _minSpawnPosition = Camera.main.ViewportToWorldPoint(new Vector2(0.05f, 0)).x;
        _maxSpawnPosition = Camera.main.ViewportToWorldPoint(new Vector2(0.95f, 0)).x;
    }

    private void Update()
    {
        _elepsedTime += Time.deltaTime;

        if (_elepsedTime >= _delayBetweenSpawn)
        {
            TrySpawn();
            _elepsedTime = 0;
        }
    }

    private void TrySpawn()
    {
        if (TryGetRandomObject(out GameObject newObject))
        {
            newObject.SetActive(true);
            float randomPositionX = Random.Range(_minSpawnPosition, _maxSpawnPosition);
            newObject.transform.position = new Vector2(randomPositionX, transform.position.y);
        }
    }
}
