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

        protected Rigidbody2D Rigidbody { get; set; }

        #region Interface Properties
        public abstract float MovementSpeed { get; set; }
        public abstract float DirectionTimer { get; set; }
        public abstract float ShootingTimer { get; set; }

        #endregion

        #region Events
        public event EventHandler DirectionTimerZero;
        public event EventHandler<ShootingEventArgs> ShootingTimerZero;

        public class ShootingEventArgs : EventArgs {
            public string shootingMessage;
        }

        #endregion

        #region MonoBehaviour Callbacks
        protected virtual void Start() {
            Rigidbody = GetComponent<Rigidbody2D>();

            DirectionTimer = 2f;
            ShootingTimer = 2f;
            directionType = DirectionType.Down;
            UpdateDirection();

            DirectionTimerZero += OnDirectionTimerZero;
            ShootingTimerZero += OnShootingTimerZero;
        }

        protected virtual void Update() {
            DirectionTimer -= Time.deltaTime;
            if (DirectionTimer <= 0) {
                DirectionTimerZero?.Invoke(this, EventArgs.Empty);
            }

            ShootingTimer -= Time.deltaTime;
            if(ShootingTimer <= 0) {
                ShootingTimerZero?.Invoke(this, new ShootingEventArgs() { shootingMessage = "Shoot!" });
            }

            Move();
        }

        #endregion

        #region Methods
        protected void Move() {
            Rigidbody.MovePosition(transform.position + transform.up * MovementSpeed * Time.deltaTime);
        }

        #endregion

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
        private void OnDirectionTimerZero(object sender, EventArgs e) {
            directionType = (DirectionType)UnityEngine.Random.Range(0, 4);
            UpdateDirection();
            DirectionTimer = UnityEngine.Random.Range(1.5f, 4f);
        }

        private void OnShootingTimerZero(object sender, ShootingEventArgs e) {
            Debug.Log(e.shootingMessage);
            ShootingTimer = 2f;
        }

        #endregion
    }
}
