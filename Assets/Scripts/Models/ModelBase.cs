using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.ComponentModel;

namespace BattleCity {
	public class ModelBase : INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;

		public void RaisedPropertyChanged(string propertyName) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
