using BattleCity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementSpeedConfig : Config<MovementSpeedConfigItem> {
    public override string FileName => "MovementSpeed";

    public float GetMovementSpeedById(string id) {
        MovementSpeedConfigItem movementSpeedConfigItem;
        itemDic.TryGetValue(id, out movementSpeedConfigItem);

        return movementSpeedConfigItem.Movement_Speed;
    }
}
