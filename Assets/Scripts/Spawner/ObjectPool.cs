using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;


    private List<int> _spawnedPoolIndex = new List<int>();
    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected void Initialize(GameObject[] prefabs)
    {
        for (int i = 0; i < _capacity; i++)
        {
            while(true)
            {
                int randomIndex = Random.Range(0, prefabs.Length);
                if (!_spawnedPoolIndex.Contains(randomIndex))
                {
                    _spawnedPoolIndex.Add(randomIndex);
                    GameObject spawned = Instantiate(prefabs[randomIndex], _container.transform);
                    spawned.SetActive(false);

                    _pool.Add(spawned);
                    break;
                }
            }
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(o => o.activeSelf == false);

        return result != null;
    }
}
