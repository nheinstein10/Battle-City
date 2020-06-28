using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
	public interface IMovementBehaviour {
		float MovementSpeed { get; }
		void UpdateDirection();
	}
}
