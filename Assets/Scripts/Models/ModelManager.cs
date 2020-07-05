using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;
using System;

namespace BattleCity {
    public class ModelManager : Singleton<ModelManager> {
        private List<ModelBase> modelList = new List<ModelBase>();

        public void Init() {

        }

        public T GetModel<T>() where T : ModelBase {
            return modelList.FirstOrDefault(m => m.GetType() == typeof(T)) as T;
        }

        protected T RegisterModel<T>(out T model) where T : ModelBase, new() {
            model = GetModel<T>();
            if(model != null) {
                Debug.LogAssertionFormat("Model {0} duplicated!", typeof(T).Name);
                return model;
            }

            model = new T();
            modelList.Add(model);

            return model;
        } 

        public void WriteModel<T>() where T : ModelBase {
            WriteModel(GetModel<T>());
        }

        protected void WriteModel(ModelBase model) {
            var dataJson = model.GetModelDataJson();
            PlayerPrefs.SetString(GetKeyName(model.GetType()), dataJson);
        }

        public bool ReadModel<T>() where T : ModelBase {
            return ReadModel(GetModel<T>());
        }

        protected bool ReadModel(ModelBase model) {
            var dataJson = PlayerPrefs.GetString(GetKeyName(model.GetType()), "");
            if (dataJson == "" || dataJson == "{}") {
                return false;
            }

            model.InitWithDataJson(dataJson);
            return true;
        }

        public string GetKeyName(Type type) {
            return string.Format("MODEL_{0}", type.Name.ToUpper());
        }
    }
}
