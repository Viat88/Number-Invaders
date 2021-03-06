using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    /*
        Makes the object rotating
    */

    public Vector3 rotationSpeed;                           // The rotation's speed

    void Update()
    {
        transform.Rotate(rotationSpeed*Time.deltaTime);
    }
}
