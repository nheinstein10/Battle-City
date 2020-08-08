using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BattleCity {
    public interface PoolObject {
    }

    public class BulletPooler : MonoBehaviour {
        public static BulletPooler Instance { get; set; }
        public List<Bullet> pooledObjects;
        public Bullet objectToPool;
        public int amountToPool;

        protected virtual void Awake() {
            if(Instance == null) {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            } else {
                Destroy(gameObject);
            }
        }

        protected virtual void Start() {
            pooledObjects = new List<Bullet>();
            for(int i = 0; i < amountToPool; i++) {
                Bullet bullet = Instantiate<Bullet>(objectToPool);
                bullet.gameObject.SetActive(false);
                pooledObjects.Add(bullet);
            } 
        }

        public virtual Bullet GetPooledObject() {
            for(int i = 0; i < pooledObjects.Count; i++) {
                if(!pooledObjects[i].gameObject.activeInHierarchy) {
                    return pooledObjects[i];
                }
            }

            return null;
        }
    }
}
