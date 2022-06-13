using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{
    /*
        Translate the object
    */

    public float movementSpeed;                                             // Movement's speed
    public Vector3 direction;                                               // Movement's direction

    void Update()
    {
        transform.Translate(direction * movementSpeed*Time.deltaTime);
    }
}
