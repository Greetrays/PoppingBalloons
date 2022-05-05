using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class Pool : MonoBehaviour
{
    [SerializeField] private GameObject _container;

    private List<GameObject> _pool = new List<GameObject>();

    public void Reset()
    {
        foreach (var item in _pool)
            item.SetActive(false);
    }

    protected void Init(int size, GameObject tepmplate)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject newObject = Instantiate(tepmplate, _container.transform);
            newObject.SetActive(false);
            _pool.Add(newObject);
        }
    }

    protected bool TryGetRandomObject(out GameObject obj)
    {
        List<GameObject> activeObjects = _pool.Where(item => item.activeSelf == false).ToList();
        obj = null;

        if (activeObjects.Count > 0)
        {
            int randomIndex = Random.Range(0, activeObjects.Count);
            obj = activeObjects[randomIndex];
        }

        return obj != null;
    }
}
