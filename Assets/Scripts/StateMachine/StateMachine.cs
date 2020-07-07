using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
	public class StateMachine {
		public StateBase CurrentState { get; private set; }

		public void Initialize(StateBase startingState) {
			CurrentState = startingState;
			startingState.Enter();
		}

		public void ChangeState(StateBase newState) {
			if (newState == CurrentState) {
				return;
			}

			CurrentState.Exit();

			CurrentState = newState;
			newState.Enter();
		}
	}
}
