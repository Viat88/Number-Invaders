using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchedByTurret : MonoBehaviour
{
    /*
        If an alien is touched by the gun turret, it destroys invincibility
    */

    private void OnTriggerEnter(Collider other){

        if (other.CompareTag("TurretMissile")){
            SoundManager.current.PlayAlienTouchedSound();
            AlienManager.current.isInvincible = false;
        }
        
    }
}
