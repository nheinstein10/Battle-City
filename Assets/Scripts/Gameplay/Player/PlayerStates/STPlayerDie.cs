using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
	public class STPlayerDie : State<Player> {
		public STPlayerDie(Player agent, StateMachine stateMachine) : base(agent, stateMachine) { }

		public override void Enter() {
			
		}
	}
}
