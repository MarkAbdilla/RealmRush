using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] int numberOfEnemiesToSpawn = 5;
    [SerializeField] Text spawnedEnemies;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;

    int score = 0;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
        spawnedEnemies.text = score.ToString();
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i <= numberOfEnemiesToSpawn; i++)
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            score++;
            spawnedEnemies.text = score.ToString();
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
