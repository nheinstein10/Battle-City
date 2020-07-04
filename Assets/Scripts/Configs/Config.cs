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

	public abstract class Config<TConfigItem> : IConfig where TConfigItem : IConfigItem, new() {
		public abstract string FileName { get; }

		public List<TConfigItem> itemList { get; private set; }
		public Dictionary<string, TConfigItem> itemDic { get; private set; }

		public void Load() {
			var filePath = Application.streamingAssetsPath + "/Configs/" + FileName + ".csv";

			itemList = new List<TConfigItem>();
			itemDic = new Dictionary<string, TConfigItem>();

			using(var reader = new StreamReader(filePath)) {
				using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) {
					csv.Configuration.Delimiter = ",";
					var records = csv.GetRecords<TConfigItem>();
					foreach(var record in records) {
						itemList.Add(record);
						itemDic.Add(record.GetId(), record);
					}
				}
			}			
		}
	}
}
