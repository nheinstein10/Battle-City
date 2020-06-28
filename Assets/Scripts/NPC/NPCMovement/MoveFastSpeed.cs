using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
    public class MoveFastSpeed : IMovementBehaviour {
        private float movementSpeed = 20f;
        public float MovementSpeed => movementSpeed;

        public void SetDirection() {
            throw new System.NotImplementedException();
        }
    }
}
