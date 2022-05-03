using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{

    public float movementSpeed;
    private Vector3 missileDirection = new Vector3(0,0,1);

    void Update()
    {
        transform.Translate(missileDirection * movementSpeed*Time.deltaTime);
    }
}
