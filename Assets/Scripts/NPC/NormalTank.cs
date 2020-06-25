using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTank : Enemy, INPC
{
    float movementSpeed = 5f;

    public void Shoot() {
        Debug.Log("Normal tank shoot");
    }
}
