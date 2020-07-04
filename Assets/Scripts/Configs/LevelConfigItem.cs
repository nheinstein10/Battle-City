using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
    public class LevelConfigItem : IConfigItem {
        public int Level { get; set; }
        public int NormalTankNumber { get; set; }
        public int SpeedTankNumber { get; set; }
        public int ArmoredTankNumber { get; set; }

        public string GetId() {
            return Level.ToString();
        }
    }
}
