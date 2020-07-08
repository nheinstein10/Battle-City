using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
    public class MoveNormalSpeed : IMovementBehaviour {
        private float _movementSpeed = 10f;

        public float MovementSpeed { get => _movementSpeed; set => _movementSpeed = value; }

        public void UpdateDirection() {
            throw new System.NotImplementedException();
        }
    }
}
