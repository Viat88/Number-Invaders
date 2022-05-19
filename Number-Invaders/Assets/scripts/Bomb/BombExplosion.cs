using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{

    public GameObject shockWavePrefab;


///////////////////////// START FUNCTIONS ///////////////////////////////////

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


////////////////////////////////////////////////////////////

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
