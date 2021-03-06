using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicArenaWave : EnemeyWave
{
    [SerializeField] private List<GameObject> enemies;

    private int enemiesAlive = 0;
    private System.Random random = new System.Random();

    public override void SpawnWave()
    {
        foreach (var enemy in enemies)
            SpawnEnemy(enemy);
    }

    public override bool WaveComplete()
    {
        return enemiesAlive <= 0;
    }

    protected void SpawnEnemy(GameObject enemy)
    {
        Vector3 position = new Vector3(random.Next(-2, 11), random.Next(-1, 3), 0);
        GameObject enemySpawned = Instantiate(enemy, position, Quaternion.identity);
        Health enemyHealth = enemySpawned.GetComponent<Health>();
        enemyHealth.OnDeath += OnEnemyDeath;
        enemiesAlive += 1;
    }

    private void OnEnemyDeath(object sender, EventArgs e)
    {
        enemiesAlive -= 1;
    }
}
