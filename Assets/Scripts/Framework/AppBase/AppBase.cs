using BattleCity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
	public abstract class AppBase : MonoBehaviour {
		protected virtual void Awake() {
			OnInit();
		}

		protected virtual void Update() {
			OnUpdate();
		}

		protected virtual void FixedUpdate() {
			OnFixedUpdate();
		}

		public virtual void OnInit() { }
		public virtual void OnUpdate() { }
		public virtual void OnFixedUpdate() { }
	}
}