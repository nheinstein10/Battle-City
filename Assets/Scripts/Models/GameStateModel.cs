using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace BattleCity {
    public class GameStateModel : ModelBase {
        public GameStateModel() : base() { }

        [JsonProperty]
        private int _currentLevel;

        public int CurrentLevel {
            get => _currentLevel;
            set {
                if(_currentLevel == value) {
                    return;
                }
                _currentLevel = value;
                RaisePropertyDataChange(this.GetType());
                ModelManager.Instance.WriteModel<GameStateModel>();
            }
        }

        public override void InitBaseData() {
            CurrentLevel = 1;
        }

        public override void OnAfterInit() {
            
        }
    }
}
