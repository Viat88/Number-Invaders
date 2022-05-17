using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{

    public GameObject shockWavePrefab;
    private bool firstTimeTouchingBackground = true;


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
        if (other.CompareTag("Background"))                    // If it's the good tagFilter
        {
            if (!firstTimeTouchingBackground){
                SoundManager.current.PlayBombExplosionSound();
                ShockWave();
                Destroy(gameObject);                            // We destroy the object
            }
            firstTimeTouchingBackground = false;
            
        }
    }



    private void ShockWave(){
        GameObject shockWave = Instantiate(shockWavePrefab, transform.position, new Quaternion(0,0,0,0));
    }
}
