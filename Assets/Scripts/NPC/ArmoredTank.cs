using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
	public class ArmoredTank : Enemy, IEnemyShootBehaviour {
        #region Fields
        float _movementSpeed = 5f;
		float _shootingTimer;

        #endregion

        #region Properties
        public override float MovementSpeed { get => _movementSpeed; set => _movementSpeed = value; }
		public override float ShootingTimer { get => _shootingTimer; set => _shootingTimer = value; }

        #endregion
    }
}
