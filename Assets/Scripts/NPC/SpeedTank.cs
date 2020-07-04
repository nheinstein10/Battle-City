using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace BattleCity {
    public class SpeedTank : Enemy, IEnemyShootBehaviour {
        #region Fields
        float _movementSpeed;
        float _directionTimer;
        float _shootingTimer;

        #endregion

        #region Properties
        public override float DirectionTimer { get => _directionTimer; set => _directionTimer = value; }
        public override float MovementSpeed { get => _movementSpeed; set => _movementSpeed = value; }
        public override float ShootingTimer { get => _shootingTimer; set => _shootingTimer = value; }

        #endregion

        #region MonoBehaviour Callbacks
        protected override void Start() {
            base.Start();

            Rigidbody = GetComponent<Rigidbody2D>();

            MovementSpeed = ConfigManager.Instance.MovementSpeedConfig.GetMovementSpeedById(nameof(NPCType.Speed));
        }

        protected override void Update() {
            base.Update();
        }

        #endregion
    }
}
