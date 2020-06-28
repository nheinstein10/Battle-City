using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
	public class ArmoredTank : Enemy, INPC, IMovementBehaviour, IEnemyShootBehaviour {
		public float ShootingTimer { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

		public float MovementSpeed => throw new System.NotImplementedException();

		public void UpdateDirection() {
			throw new System.NotImplementedException();
		}

		public void Shoot() {
			throw new System.NotImplementedException();
		}
	}
}
