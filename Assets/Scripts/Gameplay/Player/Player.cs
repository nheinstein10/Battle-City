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

            if (Input.GetButtonDown("Fire1")) {
                Shoot();
            }
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

        public void UpdateDirection(DirectionType _directionType) {
            switch (_directionType) {
                case DirectionType.Up:
                    transform.eulerAngles = new Vector3(0f, 0f, 0f);
                    break;
                case DirectionType.Left:
                    transform.eulerAngles = new Vector3(0f, 0f, 90f);
                    break;
                case DirectionType.Down:
                    transform.eulerAngles = new Vector3(0f, 0f, 180f);
                    break;
                case DirectionType.Right:
                    transform.eulerAngles = new Vector3(0f, 0f, 270f);
                    break;
                default:
                    transform.eulerAngles = new Vector3(0f, 0f, 180f);
                    break;
            }
        }

        public void Shoot() {
            Bullet bullet = BulletPooler.Instance.GetPooledObject();
            if(bullet != null) {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.gameObject.SetActive(true);
                bullet.Bullet_OnActive();
            }
        }

        public class States {
            public STPlayerSpawn Spawn { get; private set; }
            public STPlayerIdle Idle { get; private set; }
            public STPlayerMove Move { get; private set; }
            public STPlayerDie Die { get; private set; }
            public States(Player player, StateMachine smPlayer) {
                Spawn = new STPlayerSpawn(player, smPlayer);
                Idle = new STPlayerIdle(player, smPlayer);
                Move = new STPlayerMove(player, smPlayer);
                Die = new STPlayerDie(player, smPlayer);
            }
        }
    }
}
