using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : SingletonMonobehavior<EnemySpawner>
{
    [SerializeField] Enemy enemyToSpawn;
    [Range(1, 10)]
    [SerializeField] private int spawnQuantityEachTimes = 2;
    [SerializeField] private float deltaTimeSpawn = 1f;
    [SerializeField] private float spawnMaxRadius = 5f;
    [SerializeField] private float spawnMinRadius = 1f;

    private float timeElapsed;
    private List<Enemy> enemyList;

    private void Start()
    {
        enemyList = new List<Enemy>();
    }

    private void OnEnable()
    {
        EventHandler.AfterKillEnemy += DeleteEnemy;
    }

    private void OnDisable()
    {
        EventHandler.AfterKillEnemy -= DeleteEnemy;
    }

    private void Update()
    {
        if(timeElapsed < deltaTimeSpawn)
        {
            timeElapsed += Time.deltaTime;
        }
        else
        {
            timeElapsed = 0;
            SpawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        if(enemyToSpawn != null)
        {
            for(int i = 0; i < spawnQuantityEachTimes; i++)
            {
                Vector3 playerPosition = Player.Instance.transform.position;
                float spawnRadius = Random.Range(spawnMinRadius, spawnMaxRadius);
                float spawnAngle = Random.Range(0, 360);
                Vector3 spawnPosition = new Vector3(spawnRadius * Mathf.Cos(spawnAngle) + playerPosition.x, spawnRadius * Mathf.Sin(spawnAngle) + playerPosition.y, 0);
                GameObject enemy = PoolManager.Instance.ReuseObject(enemyToSpawn.enemyPrefab, spawnPosition, Quaternion.identity);
                enemy.SetActive(true);
                enemyList.Add(enemy.GetComponent<Enemy>());
            }
        }
    }

    private void DeleteEnemy(Enemy enemy)
    {
        enemyList.Remove(enemy);
    }

    public Enemy FindEnemy()
    {
        Enemy nearestEnemy = null;
        float distance = float.MaxValue;
        foreach(Enemy enemy in enemyList)
        {
            if (enemy.DistanceToPlayer() < distance)
            {
                distance = enemy.DistanceToPlayer();
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }
}
