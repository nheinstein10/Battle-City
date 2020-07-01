using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
	public class MovementSpeedConfigItem : IConfigItem {
		public string Id;
		public float movementSpeed;

		public void ReadImplement() {
			throw new System.NotImplementedException();
		}
	}
}
