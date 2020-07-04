using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace BattleCity {
    public class ConfigManager : Singleton<ConfigManager> {
        public MovementSpeedConfig MovementSpeedConfig;
        public LevelConfig LevelConfig;

        private List<IConfig> configList = new List<IConfig>();

        private void Awake() {
            this.Init();
        }

        public void Init() {
            Register(out MovementSpeedConfig);
            Register(out LevelConfig);

            LoadConfigs();
        }

        public TConfig GetConfig<TConfig>() where TConfig : IConfig {
            return (TConfig)configList.FirstOrDefault(m => m.GetType() == typeof(TConfig));
        }

        public TConfig Register<TConfig>(out TConfig config) where TConfig : IConfig, new() {
            config = GetConfig<TConfig>();
            if (config != null) {
                Debug.LogAssertionFormat("Config {0} duplicated!", typeof(TConfig).Name);
                return config;
            }

            config = new TConfig();
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
