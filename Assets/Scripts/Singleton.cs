using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
    public class Singleton<T> : MonoBehaviour where T : Component {
        private static T _instance;
        public static bool isQuiting;

        public static T Instance {
            get {
                if (_instance == null) {
                    _instance = FindObjectOfType<T>();

                    if (_instance == null) {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        _instance = obj.AddComponent<T>();
                    }
                }

                return _instance;
            }
        }

        // virtual Awake() that can be overridden in a derived class.
        public virtual void Awake() {
            if (_instance == null) {
                _instance = this as T;

                DontDestroyOnLoad(this.gameObject);
            } else {
                Destroy(gameObject);
            }
        }
    }
}
