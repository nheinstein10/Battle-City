using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
    public class STPlayerIdle : State<Player> {
        public event System.Action ChangeToMoveState;

        public STPlayerIdle(Player agent, StateMachine stateMachine) : base(agent, stateMachine) {
        }

        public override void Enter() {
            Debug.Log("Idle state");
            ChangeToMoveState += STPlayerIdle_OnChangeToMoveState;
        }

        public override void LogicUpdate(float deltaTime) {
            //Debug.Log("Idling");
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow)) {
                ChangeToMoveState?.Invoke();
            }
        }

        #region Event Methods
        private void STPlayerIdle_OnChangeToMoveState() {
            agent.SM_Player.ChangeState(agent.states.Move);
        }

        #endregion
    }
}
