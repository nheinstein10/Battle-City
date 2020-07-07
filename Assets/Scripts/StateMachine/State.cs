using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
	public abstract class StateBase {
		protected StateMachine stateMachine;

		protected StateBase(StateMachine stateMachine) {
			this.stateMachine = stateMachine;
		}

		public virtual void Enter() { }

		public virtual void LogicUpdate() { }

		public virtual void PhysicsUpdate() { }

		public virtual void Exit() { }
	}

	public abstract class State<TAgent> : StateBase {
		protected TAgent agent;

		protected State(TAgent agent, StateMachine stateMachine) : base(stateMachine) {
			this.agent = agent;
		}
	}
}
