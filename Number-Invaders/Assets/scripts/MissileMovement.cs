using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{

    public float movementSpeed;
    private Vector3 missileDirection;

    void Update()
    {
        transform.Translate(missileDirection * movementSpeed*Time.deltaTime);
    }


    public void setDirection(Vector3 direction){
        missileDirection = direction;
    }
}
