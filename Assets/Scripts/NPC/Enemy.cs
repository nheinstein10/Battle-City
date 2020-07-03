using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
    internal delegate void EnemySpawnHandler();
    public delegate void TankShootHandler();

    public abstract class Enemy : MonoBehaviour, INPC, IMovementBehaviour, ICopyable {
        protected IMovementBehaviour movementBehaviour;

        [SerializeField] protected DirectionType directionType;

        #region Interface Properties
        public abstract float MovementSpeed { get; set; }
        public abstract float ShootingTimer { get; set; }

        #endregion

        #region Events
        public event EventHandler TimerZero;
        public event EventHandler TankShoot;

        #endregion

        #region MonoBehaviour Callbacks
        protected virtual void Start() {
            ShootingTimer = 2f;
            directionType = DirectionType.Down;
            UpdateDirection();

            TimerZero += OnTimerZero;
            TankShoot += OnTankShoot;
        }

        protected virtual void Update() {
            ShootingTimer -= Time.deltaTime;
            if (ShootingTimer <= 0) {
                TimerZero?.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion

        public void ApplyMovement() {
            movementBehaviour.UpdateDirection();
        }
        public void SetMovementBehaviour(IMovementBehaviour moveType) {
            this.movementBehaviour = moveType;
        }

        #region Interface Methods
        public void UpdateDirection() {
            switch (directionType) {
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
            throw new System.NotImplementedException();
        }

        public ICopyable Copy() {
            return Instantiate(this, NPCFactory.Instance.spawnPoints[UnityEngine.Random.Range(0, NPCFactory.Instance.spawnPoints.Count)].position, Quaternion.identity);
        }

        public void SetName(string name) {
            this.gameObject.name = name;
        }

        #endregion

        #region Event Methods
        private void OnTimerZero(object sender, EventArgs e) {
            directionType = (DirectionType)UnityEngine.Random.Range(0, 4);
            UpdateDirection();
            ShootingTimer = UnityEngine.Random.Range(1.5f, 4f);
        }

        private void OnTankShoot(object sender, EventArgs e) {
            Debug.Log("Shoot!");
        }

        #endregion
    }
}
