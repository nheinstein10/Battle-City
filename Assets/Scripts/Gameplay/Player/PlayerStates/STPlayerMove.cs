using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
    public class STPlayerMove : State<Player> {
        Rigidbody2D PlayerRigidBody { get; set; }
        float playerMovementSpeed = 10f;

        float changeStateTimer = 2f;

        #region Events
        public event System.Action ChangeStateTimerZero;
        public event EventHandler<DirectionChangeEventArgs> DirectionChange;

        public class DirectionChangeEventArgs : EventArgs {
            public DirectionType DirectionType { get; set; }

            public DirectionChangeEventArgs(DirectionType _directionType) {
                DirectionType = _directionType;
            }
        }

        #endregion

        public STPlayerMove(Player agent, StateMachine stateMachine) : base(agent, stateMachine) {
            PlayerRigidBody = agent.GetComponent<Rigidbody2D>();
        }

        public override void Enter() {
            ChangeStateTimerZero += STPlayerMove_OnChangeStateTimerZero;
            DirectionChange += STPlayerMove_OnDirectionChange;
        }

        public override void LogicUpdate(float deltaTime) {
            if(Input.GetKeyDown(KeyCode.UpArrow)) {
                DirectionChange?.Invoke(this, new DirectionChangeEventArgs(DirectionType.Up));
            } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                DirectionChange?.Invoke(this, new DirectionChangeEventArgs(DirectionType.Left));
            } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
                DirectionChange?.Invoke(this, new DirectionChangeEventArgs(DirectionType.Down));
            } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
                DirectionChange?.Invoke(this, new DirectionChangeEventArgs(DirectionType.Right));
            }

            if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow)) {
                MoveForward();
            }
        }

        public void MoveForward() {
            PlayerRigidBody.MovePosition(agent.transform.position + agent.transform.up * playerMovementSpeed * Time.deltaTime);
        }

        #region Event Methods
        private void STPlayerMove_OnChangeStateTimerZero() {
            Debug.Log("OnChangeStateTimerZero");
            agent.SM_Player.ChangeState(agent.states.Idle);
            changeStateTimer = 2f;
        }

        private void STPlayerMove_OnDirectionChange(object sender, DirectionChangeEventArgs e) {
            agent.UpdateDirection(e.DirectionType);
        }

        #endregion
    }
}
