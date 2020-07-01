using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace BattleCity {
	public interface IConfig {
		void Load();
	}

	public interface IConfigItem {
		void ReadImplement();
	}

	public abstract class Config<T> : IConfig where T : IConfigItem {
		public abstract string FileName { get; }

		public void Load() {
			var fullPath = "Game/Configs/" + FileName;
		}
	}
}
