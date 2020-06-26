using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BattleCity {
    public delegate void TankShootHandler();

    public class NormalTank : Enemy, INPC, IMovementBehaviour {
        float _movementSpeed = 10f;
        public float MovementSpeed => _movementSpeed;

        public event EventHandler NormalTankShoot;

        private void Start() {
            NormalTankShoot += OnNormalTankShoot;
        }

        private void Update() {
            if(Input.GetKeyDown(KeyCode.Space)) {
                NormalTankShoot?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Move() {
            throw new System.NotImplementedException();
        }

        public void OnNormalTankShoot(object sender, EventArgs e) {
            this.Shoot();
        }

        public void Shoot() {
            Debug.Log("Normal tank shoot");
        }
    }
}
