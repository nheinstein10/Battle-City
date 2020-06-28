using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace BattleCity {
    public class MoveSlow : IMovementBehaviour {
        private float _movementSpeed = 5f;

        public float MovementSpeed { get => _movementSpeed; set => _movementSpeed = value; }

        public void UpdateDirection() {

        }
    }
}
