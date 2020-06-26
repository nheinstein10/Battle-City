using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
    internal delegate void EnemySpawnHandler();

    public class Enemy : MonoBehaviour, ICopyable {
        protected IMovementBehaviour movementBehaviour;
        public void ApplyMovement() {
            movementBehaviour.Move();
        }
        public void SetMovementBehaviour(IMovementBehaviour moveType) {
            this.movementBehaviour = moveType;
        }

        public ICopyable Copy() {
            return Instantiate(this);
        }
    }
}
