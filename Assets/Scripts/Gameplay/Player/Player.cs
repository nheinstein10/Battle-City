using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
    public class Player : MonoBehaviour {
        public Animator animator;

        public StateMachine SM_Player { get; private set; }
        public States states { get; private set; }

        public static event System.Action<Player> onPlayerSpawn;
        public static event System.Action<Player> onPlayerDie;

        private void Update() {
            
        }

        private void FixedUpdate() {
            
        }

        public class States {
            public States(Player player, StateMachine smPlayer) {

            }
        }
    }
}
