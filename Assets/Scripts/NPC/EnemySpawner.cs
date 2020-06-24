﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public ICopyable copy;
    public Enemy SpawnEnemy(Enemy prototype) {
        copy = prototype.Copy();
        return (Enemy)copy;
    }
}
