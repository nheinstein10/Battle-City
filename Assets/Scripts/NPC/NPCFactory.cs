using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFactory : MonoBehaviour
{
    public INPC GetNPC(NPCType type) {
        switch(type) {
            case NPCType.NormalTank:
                INPC normalTank = Instantiate(Resources.Load<NormalTank>("Prefabs/NormalTankNPC"));
                return normalTank;
            case NPCType.SpeedTank:
                INPC speedTank = Instantiate(Resources.Load<SpeedTank>("Prefabs/SpeedTankNPC"));
                return speedTank;
        }

        return null;
    }
}
