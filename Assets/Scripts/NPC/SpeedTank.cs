using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
    public class SpeedTank : Enemy, INPC {
        float movementSpeed = 10f;


        public void Shoot() {
            Debug.Log("Speed tank shoot");
        }
    }
}
