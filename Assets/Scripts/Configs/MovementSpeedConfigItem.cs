using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
	public class MovementSpeedConfigItem : IConfigItem {
		public string ID { get; set; }
		public float Movement_Speed { get; set; }

		public string GetId() {
			return ID.ToString();
		}
	}
}
