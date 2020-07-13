using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
    public class STPlayerMove : State<Player> {
        Rigidbody2D PlayerRigidBody { get; set; }
        float playerMovementSpeed = 10f;

        float changeStateTimer = 2f;

        #region Events
        public event Action ChangeStateTimerZero;

        #endregion

        public STPlayerMove(Player agent, StateMachine stateMachine) : base(agent, stateMachine) {
            PlayerRigidBody = agent.GetComponent<Rigidbody2D>();
        }

        public override void Enter() {
            ChangeStateTimerZero += STPlayerMove_OnChangeStateTimerZero;
        }

        public override void LogicUpdate(float deltaTime) {
            changeStateTimer -= Time.deltaTime;
            if(changeStateTimer <= 0) {
                ChangeStateTimerZero?.Invoke();
            }

            if (Input.GetKey(KeyCode.UpArrow)) {
                PlayerRigidBody.MovePosition(agent.transform.position + agent.transform.up * playerMovementSpeed * Time.deltaTime);
            }
        }

        #region Event Methods
        private void STPlayerMove_OnChangeStateTimerZero() {
            Debug.Log("OnChangeStateTimerZero");
            agent.SM_Player.ChangeState(agent.states.Idle);
            changeStateTimer = 2f;
        }


        #endregion
    }
}
