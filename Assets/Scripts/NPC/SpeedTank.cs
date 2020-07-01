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

        #region Events
        public event EventHandler TimerZero;

        #endregion

        #region MonoBehaviour Callbacks
        protected override void Start() {
            base.Start();

            rigidbody = GetComponent<Rigidbody2D>();

            TimerZero += SpeedTank_TimerZero;
        }

        protected override void Update() {
            base.Update();

            if(ShootingTimer <= 0) {
                TimerZero?.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion

        public void Shoot() {
            Debug.Log("Speed tank shoot");
        }

        #region Event Methods
        private void SpeedTank_TimerZero(object sender, EventArgs e) {
            directionType = (DirectionType)UnityEngine.Random.Range(0, 4);
            UpdateDirection();
            ShootingTimer = 2f;
        }

        #endregion
    }
}
