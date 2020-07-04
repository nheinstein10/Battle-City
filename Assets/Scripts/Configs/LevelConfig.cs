using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
    public class LevelConfig : Config<LevelConfigItem> {
        public override string FileName => "Level";

        public LevelConfigItem GetConfigItemByLevel(int level) {
            LevelConfigItem levelConfigItem;
            itemDic.TryGetValue(level.ToString(), out levelConfigItem);

            return levelConfigItem;
        }
    }
}
