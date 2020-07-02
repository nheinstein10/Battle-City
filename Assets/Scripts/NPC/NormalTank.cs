using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace BattleCity {
    public class NormalTank : Enemy, IEnemyShootBehaviour {
        #region Fields
        float _movementSpeed;
        float _shootingTimer;

        Rigidbody2D rigidbody;

        #endregion

        #region Properties
        public override float MovementSpeed { get => _movementSpeed; set => _movementSpeed = value; }
        public override float ShootingTimer { get => _shootingTimer; set => _shootingTimer = value; }

        #endregion

        #region Events
        public event EventHandler NormalTankShoot;
        public event EventHandler TimerZero;

        #endregion

        #region MonoBehaviour Callbacks
        protected override void Start() {
            base.Start();

            rigidbody = GetComponent<Rigidbody2D>();

            MovementSpeed = ConfigManager.Instance.MovementSpeedConfig.GetMovementSpeedById(nameof(NPCType.Normal));

            NormalTankShoot += OnNormalTankShoot;
            TimerZero += NormalTank_TimerZero;
        }

        private void Update() {
            base.Update();

            if(ShootingTimer <= 0) {
                TimerZero?.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion

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
