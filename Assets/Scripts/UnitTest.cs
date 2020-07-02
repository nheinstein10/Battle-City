using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
	public class UnitTest : MonoBehaviour {
		private void Start() {
			Debug.Log(ConfigManager.Instance.MovementSpeedConfig.GetMovementSpeedById(nameof(NPCType.Normal)));
			Debug.Log(ConfigManager.Instance.MovementSpeedConfig.GetMovementSpeedById(nameof(NPCType.Speed)));
			Debug.Log(ConfigManager.Instance.MovementSpeedConfig.GetMovementSpeedById(nameof(NPCType.Armored)));
		}
	}
}
