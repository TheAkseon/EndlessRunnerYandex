using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private float _secondsBeetwenSpawn;

    private SpawnPoint[] _spawnPoints;
    private float _elapsedTime = 0;

    private void Awake()
    {
        Initialize(_enemyPrefabs);
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        _secondsBeetwenSpawn = Random.Range(1.5f, 3f);

        if(_elapsedTime >= _secondsBeetwenSpawn)
        {
            if(TryGetObject(out GameObject enemy))
            {
                _elapsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetEnemy(enemy, _spawnPoints[spawnPointNumber].transform.position);
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
