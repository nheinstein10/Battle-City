using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BattleCity {
	public class ArmoredTank : Enemy, IEnemyShootBehaviour {
        #region Fields
        float _movementSpeed = 5f;
		float _shootingTimer;

        Rigidbody2D rigidbody;

        #endregion

        #region Properties
        public override float MovementSpeed { get => _movementSpeed; set => _movementSpeed = value; }
		public override float ShootingTimer { get => _shootingTimer; set => _shootingTimer = value; }

        #endregion

        #region Events
        public event EventHandler TimerZero;

        #endregion

        #region MonoBehaviour Callbacks
        protected override void Start() {
            base.Start();

            rigidbody = GetComponent<Rigidbody2D>();

            MovementSpeed = ConfigManager.Instance.MovementSpeedConfig.GetMovementSpeedById(nameof(NPCType.Armored));

            TimerZero += ArmoredTank_TimerZero;
        }

        protected override void Update() {
            base.Update();

            if(ShootingTimer <= 0) {
                TimerZero?.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion

        #region Event Methods
        private void ArmoredTank_TimerZero(object sender, EventArgs e) {
            directionType = (DirectionType)UnityEngine.Random.Range(0, 4);
            UpdateDirection();
            ShootingTimer = 2f;
        }

        #endregion
    }
}
