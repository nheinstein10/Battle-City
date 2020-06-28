using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
    public class SpeedTank : Enemy, IEnemyShootBehaviour {
        #region Fields
        float movementSpeed = 10f;

        #endregion

        #region Properties
        public override float ShootingTimer { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public override float MovementSpeed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        #endregion

        public void Shoot() {
            Debug.Log("Speed tank shoot");
        }
    }
}
