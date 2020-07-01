using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SQLite;
using System.IO;

namespace BattleCity {
	public class SqliteConnectionManager : MonoBehaviour {
		[SerializeField] string databaseFileName;

		private void Start() {
			//var fullPath = Path.Combine(Application.dataPath, "StreamingAssets", "1.csv");
			//Debug.Log(fullPath);
			Debug.Log(Application.persistentDataPath);
			if (!File.Exists(Application.persistentDataPath + "/" + "battle_city.db")) {
				SQLiteConnection.CreateFile(Application.persistentDataPath + "/" + "battle_city.db");
			}
		}
	}
}
