using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    /*
        Manage the explosion of the bomb when it touches the ground
    */

    public GameObject shockWavePrefab;



    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("BombTarget"))                    // If it's the good tagFilter
        {
            
            SoundManager.current.PlayBombExplosionSound();
            ShockWave();
            Destroy(gameObject);                            // We destroy the object
            
        }
    }

    private void ShockWave(){
        GameObject shockWave = Instantiate(shockWavePrefab, transform.position, new Quaternion(0,0,0,0));
    }
}
