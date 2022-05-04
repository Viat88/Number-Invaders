using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{


    private bool gunHolded = false;



///////////////////////// START FUNCTIONS ///////////////////////////////////  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1Manager.current.gunTaken == gameObject || Player2Manager.current.gunTaken == gameObject){
            gunHolded = true;                                                                                   // The gun is holded
        }

        else{
            gunHolded = false;                                                                                  // The gun isn't holded
        }
    }



////////////////////////////////////////////////////////////

    private void OnTriggerEnter( Collider other){
        
        if (other.CompareTag("Player1")){      // If it's player 1
            Player1Manager.current.onAGun = true;                                           // We are on a gun                                                               
            StartCoroutine (Player1Manager.current.TakeGunRoutine(gameObject));             // We check if player really wants the gun
        }


        
        if (other.CompareTag("Player2")){
            Player2Manager.current.onAGun = true;                                           // We are on a gun
            StartCoroutine (Player2Manager.current.TakeGunRoutine(gameObject));             // We check if player really wants the gun
        }

        if (other.CompareTag("AlienMissile") && gunHolded){
            Destroy(other.gameObject);
            PlayerHealth.current.TakeDamage();
        }
    }


////////////////////////////////////////////////////////////


    private void OnTriggerExit( Collider other){

        if (other.CompareTag("Player1")){                                                   // If it's one of the 2 players
            Player1Manager.current.onAGun = false;                                          // We are not on a gun yet
            StopCoroutine (Player1Manager.current.TakeGunRoutine(gameObject));
        }

        if (other.CompareTag("Player2")){                                                   // If it's one of the 2 players
            Player2Manager.current.onAGun = false;                                          // We are not on a gun yet
            StopCoroutine (Player2Manager.current.TakeGunRoutine(gameObject));
        }
    }


}
