﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public NPCFactory factory;

    INPC normalTank;
    INPC speedTank;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.N)) {
            normalTank = factory.GetNPC(NPCType.NormalTank);
            normalTank.Shoot();
        }

        if(Input.GetKeyDown(KeyCode.S)) {
            speedTank = factory.GetNPC(NPCType.SpeedTank);
            speedTank.Shoot();
        }
    }
}
