using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
	public class GameManager : AppBase {
		public static GameManager Instance { get; private set; }

		public ConfigManager Configs;
		public ModelManager Models;

		protected override void Awake() {
			if(Instance == null) {
				Instance = this;
				DontDestroyOnLoad(gameObject);
			} else {
				Destroy(gameObject);
			}

			base.Awake();
		}

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
