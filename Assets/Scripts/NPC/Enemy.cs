using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
    internal delegate void EnemySpawnHandler();
    public delegate void TankShootHandler();

    public class Enemy : MonoBehaviour, ICopyable {
        protected IMovementBehaviour movementBehaviour;
        public void ApplyMovement() {
            movementBehaviour.SetDirection();
        }
        public void SetMovementBehaviour(IMovementBehaviour moveType) {
            this.movementBehaviour = moveType;
        }

        public ICopyable Copy() {
            return Instantiate(this, NPCFactory.Instance.spawnPoints[Random.Range(0, NPCFactory.Instance.spawnPoints.Count)].position, Quaternion.identity);
        }
    }
}
