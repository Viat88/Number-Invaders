using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShoot : MonoBehaviour
{

    public GameObject missilePrefab;


    public void Shoot(Vector3 missileDirection){

        GameObject newMissile = Instantiate (missilePrefab, transform.position, new Quaternion(0,0,0,0));
        //newMissile.setDirection(missileDirection);

    }
}
