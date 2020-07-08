using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
    public class NPCFactory : Singleton<NPCFactory> {
        [SerializeField] public List<Transform> spawnPoints;

        public INPC GetNPC(NPCType type) {
            switch (type) {
                case NPCType.Normal:
                    INPC normalTank = Instantiate(Resources.Load<NormalTank>("Prefabs/NormalTank"), spawnPoints[Random.Range(0, spawnPoints.Count)].position, Quaternion.identity);
                    return normalTank;
                case NPCType.Speed:
                    INPC speedTank = Instantiate(Resources.Load<SpeedTank>("Prefabs/SpeedTank"), spawnPoints[Random.Range(0, spawnPoints.Count)].position, Quaternion.identity);
                    return speedTank;
                case NPCType.Armored:
                    INPC armoredTank = Instantiate(Resources.Load<ArmoredTank>("Prefabs/ArmoredTank"), spawnPoints[Random.Range(0, spawnPoints.Count)].position, Quaternion.identity);
                    return armoredTank;
            }

            return null;
        }
    }
}
