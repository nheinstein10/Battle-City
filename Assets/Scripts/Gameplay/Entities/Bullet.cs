using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
    public class Bullet : MonoBehaviour, PoolObject {
        #region Events
        public void Bullet_OnActive() {
            DeactivateAfterSeconds(2f);
        }

        #endregion

        public void DeactivateAfterSeconds(float seconds) {
            DOVirtual.DelayedCall(seconds, () => {
                gameObject.SetActive(false);
            });
        }
    }
}
