using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementBehaviour
{
    float MovementSpeed { get; }
    void Move();
}
