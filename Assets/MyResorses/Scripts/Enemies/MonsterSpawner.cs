using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;

    [SerializeField] private float spawnIntervalMin = 1f;
    [SerializeField] private float spawnIntervalMax = 5f;
    [SerializeField] private float spawnHeight = 0f;

    private float nextSpawnTime;

    private Vector2 screenBounds;

    private Transform monsterContainer;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        monsterContainer = GetComponent<Transform>();

        SetNextSpawnTime();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnMonster();
            SetNextSpawnTime();
        }
    }

    void SetNextSpawnTime()
    {
        nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
    }

    void SpawnMonster()
    {
        float spawnX = Random.Range(-screenBounds.x, screenBounds.x);
        Vector2 spawnPosition = new Vector2(spawnX, spawnHeight);

        Instantiate(monsterPrefab, spawnPosition, Quaternion.identity, monsterContainer);
    }
}
