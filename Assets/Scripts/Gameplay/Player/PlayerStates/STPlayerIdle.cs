using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
    public class STPlayerIdle : State<Player> {
        public STPlayerIdle(Player agent, StateMachine stateMachine) : base(agent, stateMachine) {
        }

        public override void Enter() {
            Debug.Log("Idle state");
        }

        public override void LogicUpdate(float deltaTime) {
            //Debug.Log("Idling");
        }
    }
}
