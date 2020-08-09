using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BattleCity {
    public interface PoolObject {
        void DeactivateAfterSeconds(float seconds);
    }

    public class BulletPooler : Singleton<BulletPooler> {
        public List<Bullet> pooledObjects;
        public Bullet objectToPool;
        public int amountToPool;

        [SerializeField] GameObject bulletPoolContainter;

        protected virtual void Start() {
            pooledObjects = new List<Bullet>();
            for(int i = 0; i < amountToPool; i++) {
                Bullet bullet = Instantiate<Bullet>(objectToPool, bulletPoolContainter.transform);
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
