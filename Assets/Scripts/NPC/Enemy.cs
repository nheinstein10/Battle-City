using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
    internal delegate void EnemySpawnHandler();
    public delegate void TankShootHandler();

    public class Enemy : MonoBehaviour, INPC, IMovementBehaviour, ICopyable {
        protected IMovementBehaviour movementBehaviour;

        [SerializeField] protected DirectionType directionType;

        #region Interface Properties
        public float MovementSpeed => throw new System.NotImplementedException();

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

        public ICopyable Copy() {
            return Instantiate(this, NPCFactory.Instance.spawnPoints[Random.Range(0, NPCFactory.Instance.spawnPoints.Count)].position, Quaternion.identity);
        }

        public void Shoot() {
            throw new System.NotImplementedException();
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

        #endregion
    }
}
