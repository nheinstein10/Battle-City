using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BattleCity {
	public class ArmoredTank : Enemy, IEnemyShootBehaviour {
        #region Fields
        float _movementSpeed;
		float _shootingTimer;

        Rigidbody2D rigidbody;

        #endregion

        #region Properties
        public override float MovementSpeed { get => _movementSpeed; set => _movementSpeed = value; }
		public override float ShootingTimer { get => _shootingTimer; set => _shootingTimer = value; }

        #endregion

        #region MonoBehaviour Callbacks
        protected override void Start() {
            base.Start();

            rigidbody = GetComponent<Rigidbody2D>();

            MovementSpeed = ConfigManager.Instance.MovementSpeedConfig.GetMovementSpeedById(nameof(NPCType.Armored));
        }

        protected override void Update() {
            base.Update();
        }

        #endregion
    }
}
