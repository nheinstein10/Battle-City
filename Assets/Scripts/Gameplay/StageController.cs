using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
	public class StageController : Singleton<StageController> {
		public Player player;

		private void Awake() {
			
		}

		private void Start() {
			Player.PlayerSpawn += Player_OnPlayerSpawn;
			Player.PlayerDie += Player_OnPlayerDie;
		}

		#region Event Methods
		private void Player_OnPlayerSpawn(Player _player) {
			this.player = _player;
		}

		private void Player_OnPlayerDie(Player player) {
			throw new System.NotImplementedException();
		}

		#endregion
	}
}
