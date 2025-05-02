using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class HorseSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _horsePrefab;
    [SerializeField]
    private float _minimumSpawnTime;
    [SerializeField]
    private float _maximumSpawnTime;

    [Header("Spawn Area")]
    [SerializeField]
    private Vector2 _spawnAreaMin = new Vector2(-10, -5);
    [SerializeField]
    private Vector2 _spawnAreaMax = new Vector2(10, 5);

    private float _timeUntilSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;

        if (_timeUntilSpawn <= 0)
        {
            Vector2 randomPosition = new Vector2(
                Random.Range(_spawnAreaMin.x, _spawnAreaMax.x),
                Random.Range(_spawnAreaMin.y, _spawnAreaMax.y)
            );

            Instantiate(_horsePrefab, randomPosition, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }
}
