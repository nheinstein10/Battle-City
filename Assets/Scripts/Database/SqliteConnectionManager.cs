using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SQLite;
using System.IO;

namespace BattleCity {
	public class SqliteConnectionManager : MonoBehaviour {
		[SerializeField] string databaseFileName;

		private void Start() {
			Debug.Log(Application.persistentDataPath);
			if (!File.Exists(Application.persistentDataPath + "/" + "battle_city.db")) {
				SQLiteConnection.CreateFile(Application.persistentDataPath + "/" + "battle_city.db"); 
			}
		}
	}
}
