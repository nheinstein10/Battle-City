using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace BattleCity {
    public class NormalTank : Enemy, IEnemyShootBehaviour {
        #region Fields
        float _movementSpeed = 10f;
        public float MovementSpeed => _movementSpeed;

        float _shootingTimer;
        public float ShootingTimer { get => _shootingTimer; set => _shootingTimer = value; }

        Rigidbody2D rigidbody;

        #endregion

        #region Events
        public event EventHandler NormalTankShoot;
        public event EventHandler TimerZero;

        #endregion

        protected override void Start() {
            base.Start();

            rigidbody = GetComponent<Rigidbody2D>();
            UpdateDirection();

            ShootingTimer = 2f;

            NormalTankShoot += OnNormalTankShoot;
            TimerZero += NormalTank_TimerZero;
        }


        private void Update() {
            ShootingTimer -= Time.deltaTime;
            if(ShootingTimer <= 0) {
                TimerZero?.Invoke(this, EventArgs.Empty);
            }
        }

        #region Methods
        

        public void Shoot() {
            Debug.Log("Normal tank shoot");
        }

        #endregion


        #region Event Methods
        public void OnNormalTankShoot(object sender, EventArgs e) {
            this.Shoot();
        }

        private void NormalTank_TimerZero(object sender, EventArgs e) {
            directionType = (DirectionType)UnityEngine.Random.Range(0, 4);
            UpdateDirection();
            ShootingTimer = 2f;
            Debug.Log("Timer zero!");

        }
        #endregion
    }
}
