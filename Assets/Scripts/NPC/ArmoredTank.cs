using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BattleCity {
	public class ArmoredTank : Enemy, IEnemyShootBehaviour {
        #region Properties
        public override float MovementSpeed { get => _movementSpeed; set => _movementSpeed = value; }
		public override float DirectionTimer { get => _directionTimer; set => _directionTimer = value; }
        public override float ShootingTimer { get => _shootingTimer; set => _shootingTimer = value; }

        #endregion

        #region MonoBehaviour Callbacks
        protected override void Start() {
            base.Start();

            Rigidbody = GetComponent<Rigidbody2D>();

            _movementSpeed = ConfigManager.Instance.MovementSpeedConfig.GetMovementSpeedById(nameof(NPCType.Armored));
        }

        protected override void Update() {
            base.Update();
        }

        #endregion
    }
}
