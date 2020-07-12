using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCity {
    public class STPlayerMoving : State<Player> {
        Rigidbody2D PlayerRigidBody { get; set; }
        float playerMovementSpeed = 10f;

        public STPlayerMoving(Player agent, StateMachine stateMachine) : base(agent, stateMachine) {
            PlayerRigidBody = agent.GetComponent<Rigidbody2D>();
        }

        public override void Enter() {
            
        }

        public override void LogicUpdate(float deltaTime) {
            if (Input.GetKey(KeyCode.UpArrow)) {
                PlayerRigidBody.MovePosition(agent.transform.position + agent.transform.up * playerMovementSpeed * Time.deltaTime);
            }
        }
    }
}
