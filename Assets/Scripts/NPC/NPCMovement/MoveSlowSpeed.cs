using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSlow : IMovementBehaviour {
    private float movementSpeed = 5f;
    public float MovementSpeed { get => movementSpeed; }

    public void Move() {
        throw new System.NotImplementedException();
    }
}
