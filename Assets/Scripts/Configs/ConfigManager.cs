using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace BattleCity {
    public class ConfigManager : MonoBehaviour {
        public MovementSpeedConfig MovementSpeedConfig;

        private List<IConfig> configList = new List<IConfig>();

        private void Start() {
            this.Init();
        }

        public void Init() {
            Register(out MovementSpeedConfig);

            LoadConfigs();
        }

        public T GetConfig<T>() where T : IConfig {
            return (T)configList.FirstOrDefault(m => m.GetType() == typeof(T));
        }

        public T Register<T>(out T config) where T : IConfig, new() {
            config = GetConfig<T>();
            if(config != null) {
                Debug.LogAssertionFormat("Config {0} duplicated!", typeof(T).Name);
                return config;
            }

            config = new T();
            configList.Add(config);

            return config;
        }

        protected void LoadConfigs() {
            foreach(var config in configList) {
                config.Load();
            }
        }
    }
}
