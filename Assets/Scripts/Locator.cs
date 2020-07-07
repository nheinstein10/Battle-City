using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleCity {
	public class Locator<T> where T : class {
		public static T Instance { get; private set; }

		public static T Set(T _instance) {
			if (_instance != null) {
				Debug.LogErrorFormat("Locator<{0}> is overrided!", typeof(T).Name);
			}
			Instance = _instance;
			return Instance;
		}

		public static void Unset(T _instance) {
			if (Instance == _instance) {
				Instance = null;
			}
		}

		public static void Clear() {
			Instance = null;
		}
	} 
}

