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

        #region MonoBehaviour Callbacks
        protected virtual void Start() {
            directionType = DirectionType.Down;
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
            return Instantiate(this, NPCFactory.Instance.spawnPoints[Random.Range(0, NPCFactory.Instance.spawnPoints.Count)].position, Quaternion.identity);
        }

        #endregion
    }
}
