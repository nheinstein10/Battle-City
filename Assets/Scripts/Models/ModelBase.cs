﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.ComponentModel;
using System;

namespace BattleCity {
	public class ModelBase {
		public event EventHandler<PropertyChangedEventArgs> PropertyChanged;

		public class PropertyChangedEventArgs : EventArgs {
			public string propertyName;

			public PropertyChangedEventArgs(string _propertyName) {
				propertyName = _propertyName;
			}
		}

		public void RaisePropertyDataChange(string dataName) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(dataName));
		}
	}
}
