using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BattleCity {
    public class NPCSpawner : MonoBehaviour {
        public NPCFactory factory;

        public EnemySpawner spawner;

        INPC normalTank, speedTank, armoredTank;

        private void Update() {
            if (Input.GetKeyDown(KeyCode.N)) {
                if (FindObjectsOfType<NormalTank>().Length != 0) {
                    normalTank = spawner.SpawnEnemy(FindObjectOfType<NormalTank>()) as INPC;
                    normalTank.SetName("Normal");
                } else {
                    normalTank = factory.GetNPC(NPCType.Normal);
                }
            }

            if (Input.GetKeyDown(KeyCode.S)) {
                speedTank = factory.GetNPC(NPCType.Speed);
            }

            if(Input.GetKeyDown(KeyCode.A)) {
                armoredTank = factory.GetNPC(NPCType.Armored);
            }
        }
    }
}
