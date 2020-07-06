using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
	public class MainGame : AppBase {
		public ConfigManager Configs;
		public ModelManager Models;

		public override void OnInit() {
			Configs = ConfigManager.Instance;
			Models = ModelManager.Instance;

			Configs.Init();
			Models.Init();
		}

		public override void OnUpdate() {
			//Debug.Log("Update");
		}
	}
}
