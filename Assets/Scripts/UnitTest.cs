using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
	public class UnitTest : MonoBehaviour {
		private void Start() {
			Debug.Log(ConfigManager.Instance.MovementSpeedConfig.GetMovementSpeedById("speed"));
			Debug.Log(ConfigManager.Instance.MovementSpeedConfig.GetMovementSpeedById("normal"));
			Debug.Log(ConfigManager.Instance.MovementSpeedConfig.GetMovementSpeedById("armored"));
		}
	}
}
