using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
    public class Player : MonoBehaviour {
        public Animator animator;

        public StateMachine SM_Player { get; private set; }
        public States states { get; private set; }

        public bool isDie => SM_Player?.CurrentState == states.Die;

        public static event System.Action<Player> PlayerSpawn;
        public static event System.Action<Player> PlayerDie;

        private void Update() {
            SM_Player.CurrentState.LogicUpdate(Time.deltaTime);
        }

        private void FixedUpdate() {
            SM_Player.CurrentState.PhysicsUpdate(Time.fixedDeltaTime);
        }

        public void Init() {
            if (SM_Player == null) {
                SM_Player = new StateMachine();
                states = new States(this, SM_Player);
                SM_Player.Initialize(states.Spawn);
            } else {
                SM_Player.ChangeState(states.Spawn);
            }
        }

        public void Spawn() {
            SM_Player.ChangeState(states.Spawn);
            PlayerSpawn?.Invoke(this);
        }

        public class States {
            public STPlayerSpawn Spawn { get; private set; }
            public STPlayerIdle Idle { get; private set; }
            public STPlayerMoving Move { get; private set; }
            public STPlayerDie Die { get; private set; }
            public States(Player player, StateMachine smPlayer) {
                Spawn = new STPlayerSpawn(player, smPlayer);
                Idle = new STPlayerIdle(player, smPlayer);
                Move = new STPlayerMoving(player, smPlayer);
                Die = new STPlayerDie(player, smPlayer);
            }
        }
    }
}
