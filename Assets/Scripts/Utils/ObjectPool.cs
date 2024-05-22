using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T prefab;
    [SerializeField] private int initialCount;
    [SerializeField] private int limit;
    
    private readonly List<T> _pooledObjects = new();
        
    private void Start()
    {
        for (var i = 0; i < initialCount; i++)
        {
            var pooled = Create();
            pooled.gameObject.SetActive(false);
            _pooledObjects.Add(pooled);
        }
    }

    public T Get(bool setActive = true)
    {
        T pooled;

        if (_pooledObjects.Count > 0)
        {
            pooled = _pooledObjects[0];
            _pooledObjects.Remove(pooled);
        }
        else
            pooled = Create();
            
        pooled.gameObject.SetActive(setActive);
        return pooled;
    }

    protected virtual T Create()
    {
        return Instantiate(prefab, transform, true);
    }

    public virtual void Release(T pooled)
    {
        if (_pooledObjects.Count <= limit)
        {
            _pooledObjects.Add(pooled);
            pooled.gameObject.SetActive(false);
        }
        else
            Destroy(pooled.gameObject);
    }
}