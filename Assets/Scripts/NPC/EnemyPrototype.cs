using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrototype : MonoBehaviour
{
    public List<Enemy> enemyTanks;

    public EnemySpawner spawner;

    private Enemy spawn;
    private void Update() {
        if(Input.GetKeyDown(KeyCode.S)) {
            spawn = spawner.SpawnEnemy(enemyTanks[0]);
        }
    }
}
