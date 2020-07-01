using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
	public class MovementSpeedConfigItem : IConfigItem {
		public string id;
		public float movementSpeed;

		public string GetId() {
			return id.ToString();
		}

		public void ReadImplement() {
			throw new System.NotImplementedException();
		}
	}
}
