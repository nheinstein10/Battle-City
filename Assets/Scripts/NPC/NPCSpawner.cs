using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BattleCity {
    public class NPCSpawner : MonoBehaviour {
        public NPCFactory factory;

        public EnemySpawner spawner;

        INPC normalTank, speedTank;

        private void Update() {
            if (Input.GetKeyDown(KeyCode.N)) {
                if (FindObjectsOfType<NormalTank>().Length != 0) {
                    normalTank = spawner.SpawnEnemy(FindObjectOfType<NormalTank>()) as INPC;
                } else {
                    normalTank = factory.GetNPC(NPCType.NormalTank);
                }
            }

            if (Input.GetKeyDown(KeyCode.S)) {
                speedTank = factory.GetNPC(NPCType.SpeedTank);
            }
        }
    }
}
