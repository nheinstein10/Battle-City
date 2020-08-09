using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
	public class STPlayerGeneral : State<Player> {
		public STPlayerGeneral(Player agent, StateMachine stateMachine) : base(agent, stateMachine) { 
		}

		public override void Enter() {
		}
	}
}
