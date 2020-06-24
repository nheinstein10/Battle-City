using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public NormalTank normalTank;

    public EnemySpawner spawner;

    private Enemy spawn;
    private void Update() {
        if(Input.GetKeyDown(KeyCode.S)) {
            spawn = spawner.SpawnEnemy(normalTank);
        }
    }
}
