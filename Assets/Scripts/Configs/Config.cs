using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using CsvHelper;

namespace BattleCity {
	public interface IConfig {
		void Load();
	}

	public interface IConfigItem {
		void ReadImplement();
		string GetId();
	}

	public abstract class Config<T> : IConfig where T : IConfigItem {
		public abstract string FileName { get; }

		public List<T> itemList { get; private set; }
		public Dictionary<string, T> itemDic { get; private set; }

		public void Load() {
			var filePath = Application.streamingAssetsPath + FileName + ".csv";
		}
	}
}
