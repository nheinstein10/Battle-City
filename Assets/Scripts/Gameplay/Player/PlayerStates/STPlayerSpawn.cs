using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
	public class STPlayerSpawn : State<Player> {
		public STPlayerSpawn(Player agent, StateMachine stateMachine) : base(agent, stateMachine) {
		}

		public override void Enter() {
			
		}

		public override void LogicUpdate(float deltaTime) {
			agent.SM_Player.ChangeState(agent.states.Idle); // for test Change State function
		}
	}
}
