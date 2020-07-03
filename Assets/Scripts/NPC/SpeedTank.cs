using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace BattleCity {
    public class SpeedTank : Enemy, IEnemyShootBehaviour {
        #region Fields
        float _movementSpeed = 20f;
        float _shootingTimer;

        Rigidbody2D rigidbody;

        #endregion

        #region Properties
        public override float ShootingTimer { get => _shootingTimer; set => _shootingTimer = value; }
        public override float MovementSpeed { get => _movementSpeed; set => _movementSpeed = value; }

        #endregion

        #region MonoBehaviour Callbacks
        protected override void Start() {
            base.Start();

            rigidbody = GetComponent<Rigidbody2D>();

            MovementSpeed = ConfigManager.Instance.MovementSpeedConfig.GetMovementSpeedById(nameof(NPCType.Speed));
        }

        protected override void Update() {
            base.Update();
        }

        #endregion

        public void Shoot() {
            Debug.Log("Speed tank shoot");
        }
    }
}
