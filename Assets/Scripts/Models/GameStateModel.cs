using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace BattleCity {
    public class GameStateModel : ModelBase {
        [JsonProperty]
        private int _currentLevel;

        public int CurrentLevel {
            get => _currentLevel;
            set {
                if(_currentLevel == value) {
                    return;
                }
                _currentLevel = value;
                RaisePropertyDataChange(nameof(CurrentLevel));
            }
        }
    }
}
