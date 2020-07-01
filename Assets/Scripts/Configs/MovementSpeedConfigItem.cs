using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
	public class MovementSpeedConfigItem : IConfigItem {
		public string id { get; set; }
		public float movementSpeed { get; set; }

		public string GetId() {
			return id.ToString();
		}
	}
}
