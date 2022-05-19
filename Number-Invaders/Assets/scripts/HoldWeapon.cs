using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldWeapon : MonoBehaviour
{
    private string player;

///////////////////////// START FUNCTIONS /////////////////////////////////// 

    // Start is called before the first frame update
    void Start()
    {
        GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

///////////////////////// TRIGGER FUNCTIONS ///////////////////////////////// 

    private void OnTriggerEnter( Collider other){

        if (other.CompareTag("Weapon")){

            if (player == "Player1"){                                                           // If it's player 1
                Player1Manager.current.onAGun = true;                                           // Player is on a gun                                                               
                StartCoroutine (Player1Manager.current.TakeGunRoutine(other.gameObject));       // We check if player really wants the gun
            }

            if (player == "Player2"){                                                           // If it's player 2
                Player2Manager.current.onAGun = true;                                           // We are on a gun
                StartCoroutine (Player2Manager.current.TakeGunRoutine(other.gameObject));       // We check if player really wants the gun
            }
        }
    }


/////////////////////

    private void OnTriggerExit( Collider other){

        if (player == "Player1"){                                                           // If it's Player 1
            Player1Manager.current.onAGun = false;                                          // He is not on a gun yet
            StopCoroutine (Player1Manager.current.TakeGunRoutine(other.gameObject));        // Player didn't want the gun
        }

        if (player == "Player2"){                                                           // If it's Player 2
            Player2Manager.current.onAGun = false;                                          // He is not on a gun yet
            StopCoroutine (Player2Manager.current.TakeGunRoutine(other.gameObject));        // Player didn't want the gun
        }
    }

////////////////////////////////////////////////////////////

    private void GetPlayer(){
        player = gameObject.tag;
    }
}
