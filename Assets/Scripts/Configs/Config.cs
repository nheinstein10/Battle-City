using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using CsvHelper;
using System.Globalization;

namespace BattleCity {
	public interface IConfig {
		void Load();
	}

	public interface IConfigItem {
		//void ReadImplement();
		string GetId();
	}

	public abstract class Config<T> : IConfig where T : IConfigItem, new() {
		public abstract string FileName { get; }

		public List<T> itemList { get; private set; }
		public Dictionary<string, T> itemDic { get; private set; }

		public void Load() {
			var filePath = Application.streamingAssetsPath + FileName + ".csv";

			itemList = new List<T>();
			itemDic = new Dictionary<string, T>();

			using(var reader = new StreamReader(filePath)) {
				using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) {
					var records = csv.GetRecords<T>();
					foreach(var record in records) {
						itemList.Add(record);
						itemDic.Add(record.GetId(), record);
					}
				}
			}			
		}
	}
}
