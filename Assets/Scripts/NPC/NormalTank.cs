using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace BattleCity {
    public class NormalTank : Enemy, INPC, IMovementBehaviour, IEnemyShootBehaviour {
        #region Fields
        float _movementSpeed = 10f;
        public float MovementSpeed => _movementSpeed;

        float _shootingTimer;
        public float ShootingTimer { get => _shootingTimer; set => _shootingTimer = value; }

        [SerializeField] DirectionType directionType;

        Rigidbody2D rigidbody;

        #endregion

        #region Events
        public event EventHandler NormalTankShoot;
        public event EventHandler TimerZero;

        #endregion

        private void Start() {
            rigidbody = GetComponent<Rigidbody2D>();

            ShootingTimer = 2f;
            directionType = DirectionType.Down;

            NormalTankShoot += OnNormalTankShoot;
            TimerZero += NormalTank_TimerZero;
        }


        private void Update() {
            //if(Input.GetKeyDown(KeyCode.Space)) {
            //    NormalTankShoot?.Invoke(this, EventArgs.Empty);
            //}

            ShootingTimer -= Time.deltaTime;
            if(ShootingTimer <= 0) {
                TimerZero?.Invoke(this, EventArgs.Empty);
            }
        }

        #region Methods
        public void SetDirection() {
            switch(directionType) {
                case DirectionType.Up:
                    transform.eulerAngles = new Vector3(0f, 0f, 0f);
                    break;
                case DirectionType.Left:
                    transform.eulerAngles = new Vector3(0f, 0f, 90f);
                    break;
                case DirectionType.Down:
                    transform.eulerAngles = new Vector3(0f, 0f, 180f);
                    break;
                case DirectionType.Right:
                    transform.eulerAngles = new Vector3(0f, 0f, 270f);
                    break;
                default:
                    transform.eulerAngles = new Vector3(0f, 0f, 180f);
                    break;
            }
        }

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
            SetDirection();
            ShootingTimer = 2f;
            Debug.Log("Timer zero!");

        }
        #endregion
    }
}
