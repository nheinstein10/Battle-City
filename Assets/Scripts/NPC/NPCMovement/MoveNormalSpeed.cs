﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
    public class MoveNormalSpeed : IMovementBehaviour {
        private float movementSpeed = 10f;
        public float MovementSpeed => movementSpeed;

        public void UpdateDirection() {
            throw new System.NotImplementedException();
        }
    }
}
