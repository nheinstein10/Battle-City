using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BattleCity {
	public abstract class UIViewBase : MonoBehaviour {
		protected virtual void Start() {
			InitView();
		}

		public void InitView() {
			OnViewInit();
		}

		protected virtual void OnViewInit() { }

		protected virtual void AddClick(Button control, UnityAction onclick) {
			Debug.AssertFormat(control, "{0} button cannot be null!", name);
			control.onClick.AddListener(onclick);
		}
	}
}
