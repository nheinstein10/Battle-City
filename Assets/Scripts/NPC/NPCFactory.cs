using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFactory : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPoints;

    public INPC GetNPC(NPCType type) {
        switch(type) {
            case NPCType.NormalTank:
                INPC normalTank = Instantiate(Resources.Load<NormalTank>("Prefabs/NormalTankNPC"), spawnPoints[Random.Range(0, spawnPoints.Count)]);
                return normalTank;
            case NPCType.SpeedTank:
                INPC speedTank = Instantiate(Resources.Load<SpeedTank>("Prefabs/SpeedTankNPC"), spawnPoints[Random.Range(0, spawnPoints.Count)]);
                return speedTank;
        }

        return null;
    }
}
