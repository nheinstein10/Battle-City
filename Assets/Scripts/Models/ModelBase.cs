using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.ComponentModel;
using System;

namespace BattleCity {
	public class ModelBase {
		public event EventHandler<PropertyChangedEventArgs> PropertyChanged;

		public ModelBase() {
			PropertyChanged += OnPropertyChanged;
		}

		public class PropertyChangedEventArgs : EventArgs {
			public Type modelType;

			public PropertyChangedEventArgs(Type _modelType) {
				modelType = _modelType;
			}
		}

		public void RaisePropertyDataChange(Type dataName) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(dataName));
		}

		public void OnPropertyChanged(object sender, PropertyChangedEventArgs e) {
			Debug.LogWarning(e.modelType);
		}

		public virtual string GetModelDataJson() {
			string dataJson = "";
			try {
				dataJson = JsonConvert.SerializeObject(this, Formatting.Indented);
			} catch(Exception e) {
				Debug.LogAssertionFormat("JsonConvert failed! {0}", this.GetType().Name);
				Debug.LogError(e.Message);
			}

			return dataJson;
		}

		public virtual void InitWithDataJson(string dataJson) {
			JsonConvert.PopulateObject(dataJson, this);
			RaisePropertyDataChange(default);
		}

		public virtual void InitBaseData() { }

		public virtual void OnAfterInit() { }
	}
}
