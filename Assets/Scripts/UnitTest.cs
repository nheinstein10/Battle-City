﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
	public class UnitTest : MonoBehaviour {
		private void Start() {
			Debug.Log(GameManager.Instance.Configs.MovementSpeedConfig.GetMovementSpeedById(Constant.PLAYER_TANK_ID));
			Debug.Log(ConfigManager.Instance.MovementSpeedConfig.GetMovementSpeedById(nameof(NPCType.Normal)));
			Debug.Log(ConfigManager.Instance.MovementSpeedConfig.GetMovementSpeedById(nameof(NPCType.Speed)));
			Debug.Log(ConfigManager.Instance.MovementSpeedConfig.GetMovementSpeedById(nameof(NPCType.Armored)));

			Debug.Log(ConfigManager.Instance.LevelConfig.GetConfigItemByLevel(1).NormalTankNumber);
			Debug.Log(ConfigManager.Instance.LevelConfig.GetConfigItemByLevel(4).NormalTankNumber);

			Debug.Log("Current level: " + GameManager.Instance.Models.GameStateModel.CurrentLevel);
		}

		private void Update() {
			if(Input.GetKeyDown(KeyCode.U)) {
				ModelManager.Instance.GameStateModel.CurrentLevel++;
			}
		}
	}
}
